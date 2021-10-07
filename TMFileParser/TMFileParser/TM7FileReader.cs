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
        private List<TM7Diagram> _tmData;
        [ExcludeFromCodeCoverage]
        public TM7FileReader(FileInfo inputFile)
        {
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
            this._tmData = new List<TM7Diagram>();

            foreach (TM7DrawingSurfaceModel model in this._tmRawData.drawingSurfaceList.drawingSurfaceModel)
            {
                var diagram = new TM7Diagram();
                diagram.diagram = model.properties.anyType.Where(d => d.type == "StringDisplayAttribute" && d.DisplayName == "Name").FirstOrDefault().value.value;
                var boundaries = new List<TM7Boundary>();
                var connectors = new List<TM7Connector>();

                foreach (TM7BordersKeyValueOfguidanyType border in model.borders.keyValueOfguidanyType)
                {
                    if (border.value.type.ToLower() == "BorderBoundary".ToLower() || border.value.type.ToLower() == "LineBoundary".ToLower())
                    {
                        var boundary = new TM7Boundary();
                        boundary.Name = border.value.properties.anyType.Where(x => x.type == "HeaderDisplayAttribute").FirstOrDefault().DisplayName;
                        boundary.DisplayName = border.value.properties.anyType.Where(x => x.type == "StringDisplayAttribute" && x.DisplayName == "Name").FirstOrDefault().value.value;
                        boundaries.Add(boundary);
                    }
                }

                foreach (TM7LinesKeyValueOfguidanyType line in model.lines.keyValueOfguidanyType)
                {
                    if (line.value.type.ToLower() == "BorderBoundary".ToLower() || line.value.type.ToLower() == "LineBoundary".ToLower())
                    {
                        var boundary = new TM7Boundary();
                        boundary.Name = line.value.properties.anyType.Where(x => x.type == "HeaderDisplayAttribute").FirstOrDefault().DisplayName;
                        boundary.DisplayName = line.value.properties.anyType.Where(x => x.type == "StringDisplayAttribute" && x.DisplayName == "Name").FirstOrDefault().value.value;
                        boundaries.Add(boundary);
                    }

                    if (line.value.type.ToLower() == "Connector".ToLower())
                    {
                        var connector = new TM7Connector();
                        connector.Name = line.value.properties.anyType.Where(x => x.type == "HeaderDisplayAttribute").FirstOrDefault().DisplayName;
                        connector.DisplayName = line.value.properties.anyType.Where(x => x.type == "StringDisplayAttribute" && x.DisplayName == "Name").FirstOrDefault().value.value;
                        connectors.Add(connector);
                    }
                }
                diagram.bondaries = boundaries;
                diagram.connectors = connectors;
                _tmData.Add(diagram);
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
                    return this._tmData;
                case "boundaries":
                    return this._tmData.Select(x => new { 
                        x.diagram,
                        x.bondaries
                    });             
                case "connectors":
                    return this._tmData.Select(x => new {
                        x.diagram,
                        x.connectors
                    });
                default:
                    throw new InvalidDataException("Invalid Get Operation:" + category);
            }
        }
    }
}
