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
            foreach(TM7KeyValueOfstringThreatpc_P0_PhOB threatInstance in _tmRawData.threatInstances.keyValueOfstringThreatpc_P0_PhOB)
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
                        boundaries.Add(boundary);
                    }
                    else
                    {
                        var asset = new TM7Asset();
                        asset.Name = border.value.properties.anyType
                            .Where(x => x.type == "HeaderDisplayAttribute").FirstOrDefault()?.DisplayName;
                        asset.DisplayName = border.value.properties.anyType
                            .Where(x => x.type == "StringDisplayAttribute" && x.DisplayName == "Name").FirstOrDefault()?.value.value;
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
                        boundaries.Add(boundary);
                    }
                    else if (line.value.type.ToLower() == "Connector".ToLower())
                    {
                        var connector = new TM7Connector();
                        connector.Name = line.value.properties.anyType
                            .Where(x => x.type == "HeaderDisplayAttribute").FirstOrDefault()?.DisplayName;
                        connector.DisplayName = line.value.properties.anyType
                            .Where(x => x.type == "StringDisplayAttribute" && x.DisplayName == "Name").FirstOrDefault()?.value.value;
                        connectors.Add(connector);
                    }
                    else
                    {
                        var asset = new TM7Asset();
                        asset.Name = line.value.properties.anyType
                            .Where(x => x.type == "HeaderDisplayAttribute").FirstOrDefault()?.DisplayName;
                        asset.DisplayName = line.value.properties.anyType
                            .Where(x => x.type == "StringDisplayAttribute" && x.DisplayName == "Name").FirstOrDefault()?.value.value;
                        assets.Add(asset);
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
