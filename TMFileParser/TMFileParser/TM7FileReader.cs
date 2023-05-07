using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TMFileParser.Interfaces;
using TMFileParser.Models.tm7;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using TMFileParser.Models.output;

namespace TMFileParser
{
    public class TM7FileReader : ITMFileReader
    {
        protected string _fileContent;
        private TM7ThreatModel _tmRawData;
        private TM7All _tmAllData;
        [ExcludeFromCodeCoverage]
        public TM7FileReader(FileInfo inputFile)
        {
            this._tmAllData = new TM7All();
            _fileContent = File.ReadAllText(inputFile.FullName);
            this.ReadTMFile();
        }

        private void ReadTMFile()
        {
            StringReader stringReader = new StringReader(this.PreProcessData(_fileContent));
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Prohibit;
            settings.XmlResolver = null;
            XmlReader xmlReader = XmlReader.Create(stringReader, settings);
            XmlSerializer serializer = new XmlSerializer(typeof(TM7ThreatModel), "http://schemas.datacontract.org/2004/07/ThreatModeling.Model");
            this._tmRawData = (TM7ThreatModel)serializer.Deserialize(xmlReader);
            this.ReadDiagramElements();
            this.ReadThreats();
        }

        private void ReadThreats()
        {
            var threats = new List<TM7Threat>();
            foreach (TM7KeyValueOfstringThreatpc_P0_PhOB threatInstance in _tmRawData.threatInstances.keyValueOfstringThreatpc_P0_PhOB)
            {
                var threat = new TM7Threat();
                threat.id = threatInstance.value.id;
                threat.diagram = this._tmRawData.drawingSurfaceList.drawingSurfaceModel
                    .Where(x => x.guid == threatInstance.value.drawingSurfaceGuid).FirstOrDefault()?
                    .properties.anyType.Where(d => d.type == "StringDisplayAttribute" && d.DisplayName == "Name")
                    .FirstOrDefault()?.value.value;
                threat.changedBy = threatInstance.value.changedBy;
                threat.lastModified = threatInstance.value.ModifiedAt;
                threat.title = threatInstance.value.properties.keyValueOfstringstring
                    .Where(x => x.key == "Title").FirstOrDefault()?.value;
                threat.category = threatInstance.value.properties.keyValueOfstringstring
                     .Where(x => x.key == "UserThreatCategory").FirstOrDefault()?.value;
                threat.description = threatInstance.value.properties.keyValueOfstringstring
                    .Where(x => x.key == "UserThreatDescription").FirstOrDefault()?.value;
                threat.justifications = threatInstance.value.properties.keyValueOfstringstring
                    .Where(x => x.key == "StateInformation").FirstOrDefault()?.value;
                threat.interaction = threatInstance.value.properties.keyValueOfstringstring
                     .Where(x => x.key == "InteractionString").FirstOrDefault()?.value;
                threat.priority = threatInstance.value.properties.keyValueOfstringstring
                    .Where(x => x.key == "Priority").FirstOrDefault()?.value;

                threats.Add(threat);
            }
            this._tmAllData.threats = threats;
        }

        private void ReadDiagramElements()
        {
            var diagrams = new List<TM7Diagram>();
            foreach (TM7DrawingSurfaceModel model in this._tmRawData.drawingSurfaceList.drawingSurfaceModel)
            {
                var diagram = new TM7Diagram();
                diagram.diagram = model.properties.anyType.Where(d => d.type == "StringDisplayAttribute" && d.DisplayName == "Name")
                    .FirstOrDefault()?.value.value;
                var boundaries = new List<TM7Boundary>();
                var connectors = new List<TM7Connector>();
                var assets = new List<TM7Asset>();

                foreach (TM7BordersKeyValueOfguidanyType border in model.borders.keyValueOfguidanyType)
                {
                    if (border.value.type.ToLower() == "BorderBoundary".ToLower() || border.value.type.ToLower() == "LineBoundary".ToLower())
                    {
                        var boundary = new TM7Boundary();
                        boundary.Name = border.value.properties.anyType
                            .Where(x => x.type == "HeaderDisplayAttribute").FirstOrDefault()?.DisplayName;
                        boundary.DisplayName = border.value.properties.anyType
                            .Where(x => x.type == "StringDisplayAttribute" && x.DisplayName == "Name").FirstOrDefault()?.value.value;
                        boundary.Type = border.value.type;
                        boundary.Height = border.value.height;
                        boundary.Width = border.value.width;
                        boundary.Left = border.value.left;
                        boundary.Top = border.value.top;
                        boundaries.Add(boundary);
                    }
                    else
                    {
                        var asset = new TM7Asset();
                        asset.Name = border.value.properties.anyType
                            .Where(x => x.type == "HeaderDisplayAttribute").FirstOrDefault()?.DisplayName;
                        asset.DisplayName = border.value.properties.anyType
                            .Where(x => x.type == "StringDisplayAttribute" && x.DisplayName == "Name").FirstOrDefault()?.value.value;
                        asset.Height = border.value.height;
                        asset.Width = border.value.width;
                        asset.Left = border.value.left;
                        asset.Top = border.value.top;
                        asset.Guid = border.value.guid;
                        assets.Add(asset);
                    }
                }

                foreach (TM7LinesKeyValueOfguidanyType line in model.lines.keyValueOfguidanyType)
                {
                    if (line.value.type.ToLower() == "BorderBoundary".ToLower() || line.value.type.ToLower() == "LineBoundary".ToLower())
                    {
                        var boundary = new TM7Boundary();
                        boundary.Name = line.value.properties.anyType
                            .Where(x => x.type == "HeaderDisplayAttribute").FirstOrDefault()?.DisplayName;
                        boundary.DisplayName = line.value.properties.anyType
                            .Where(x => x.type == "StringDisplayAttribute" && x.DisplayName == "Name").FirstOrDefault()?.value.value;
                        boundary.Type = line.value.type;
                        boundaries.Add(boundary);
                    }
                    else if (line.value.type.ToLower() == "Connector".ToLower())
                    {
                        var connector = new TM7Connector();
                        connector.Name = line.value.properties.anyType
                            .Where(x => x.type == "HeaderDisplayAttribute").FirstOrDefault()?.DisplayName;
                        connector.DisplayName = line.value.properties.anyType
                            .Where(x => x.type == "StringDisplayAttribute" && x.DisplayName == "Name").FirstOrDefault()?.value.value;
                        connector.SourceAsset = assets.Where(x => x.Guid == line.value.sourceGuid).FirstOrDefault();
                        connector.TargetAsset = assets.Where(x => x.Guid == line.value.targetGuid).FirstOrDefault();
                        connectors.Add(connector);
                    }
                }

                foreach (TM7Boundary boundary in boundaries)
                {
                    if (boundary.Type == "BorderBoundary")
                    {
                        boundary.Assets = assets.Where(x => x.Left > boundary.Left
                            && x.Left + x.Width < boundary.Left + boundary.Width
                            && x.Top > boundary.Top
                            && x.Top + x.Height < boundary.Top + boundary.Height).ToList();

                        boundary.AssetsOnBoundary = assets.Where(x => x.Left >= boundary.Left - x.Width
                            && x.Left + x.Width <= boundary.Left + boundary.Width + x.Width
                            && x.Top >= boundary.Top - x.Height
                            && x.Top + x.Height <= boundary.Top + boundary.Height + x.Height
                            &&!boundary.Assets.Contains(x)).ToList();

                        boundary.ChildBoundaries = boundaries.Where(x => x.Left > boundary.Left
                            && x.Left + x.Width < boundary.Left + boundary.Width
                            && x.Top > boundary.Top
                            && x.Top + x.Height < boundary.Top + boundary.Height).ToList();

                        

                        boundary.Connectors = new List<TM7Connector>();
                        boundary.CrossingDataflows = new List<TM7Connector>();
                        foreach (TM7Connector connector in connectors)
                        {
                            bool containsSource = boundary.Assets.Contains(connector.SourceAsset);
                            bool containsTarget = boundary.Assets.Contains(connector.TargetAsset);
                            if (containsSource && containsTarget) {
                                boundary.Connectors.Add(connector);
                            } else if ((!containsSource && containsTarget) || (containsSource && !containsTarget))
                            {
                                boundary.CrossingDataflows.Add(connector);
                            }
                        }
                    } 
                }

                foreach (TM7Boundary boundary in boundaries) {
                    if (boundary.Type == "BorderBoundary") {
                        var commonBoundaries = boundaries.Where(x => x.Left >= boundary.Left - x.Width
                             && x.Left + x.Width <= boundary.Left + boundary.Width + x.Width
                             && x.Top >= boundary.Top - x.Height
                             && x.Top + x.Height <= boundary.Top + boundary.Height + x.Height
                             && !boundary.ChildBoundaries.Contains(x)
                             && x != boundary).ToList();

                        boundary.CommonBoundaries = new List<TM7CommonBoundary>();

                        foreach (TM7Boundary commonBoundary in commonBoundaries)
                        {
                            var common = new TM7CommonBoundary();
                            common.Boundary = new TM7BoundaryBasic(commonBoundary);

                            boundary.CommonBoundaries.Add(common);

                        }
                        foreach (TM7CommonBoundary commonBoundary in boundary.CommonBoundaries) {
                            if (boundary.Assets != null && commonBoundary.Boundary.Assets != null) {
                                commonBoundary.CommonAssets = boundary.Assets?.ToList().Intersect(commonBoundary.Boundary.Assets?.ToList()).ToList();
                            }
                        }
                    }
                }

               
                diagram.boundaries = boundaries;
                diagram.connectors = connectors;
                diagram.assets = assets;
                diagrams.Add(diagram);
                this._tmAllData.diagrams = diagrams;
            }
        }

        private string PreProcessData(string fileContent)
        {
            return Regex.Replace(fileContent, "[abiz]:", "");
        }

        public object GetData(string category)
        {
            switch (category)
            {
                case "raw":
                    return this._tmRawData;
                case "all":
                    return this._tmAllData;
                case "threats":
                    return this._tmAllData.threats;
                case "boundaries":
                    return this._tmAllData.diagrams.Select(x => new {
                        x.diagram,
                        x.boundaries
                    });
                case "connectors":
                    return this._tmAllData.diagrams.Select(x => new {
                        x.diagram,
                        x.connectors
                    });
                 case "assets":
                    return this._tmAllData.diagrams.Select(x => new {
                        x.diagram,
                        x.assets
                    });
                default:
                    throw new InvalidDataException("Invalid Get Operation:" + category);
            }
        }
    }
}
