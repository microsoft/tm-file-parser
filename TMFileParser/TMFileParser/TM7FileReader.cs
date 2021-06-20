﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Text;
using System.Xml.Serialization;
using TMFileParser.Interfaces;
using TMFileParser.Models.tm7;
using System.Linq;

namespace TMFileParser
{
    public class TM7FileReader : ITMFileReader
    {
        private readonly IFileSystem _fileSystem;
        protected string _fileContent;
        private TM7ThreatModel _tmData;
        [ExcludeFromCodeCoverage]
        public TM7FileReader(FileInfo inputFile)
        {
            _fileSystem = new FileSystem();
            _fileContent = _fileSystem.File.ReadAllText(inputFile.FullName);
            this.ReadTMFile();
        }

        private void ReadTMFile()
        {
            StringReader stringReader = new StringReader(this.PreProcessData(_fileContent));
            XmlSerializer serializer = new XmlSerializer(typeof(TM7ThreatModel), "http://schemas.datacontract.org/2004/07/ThreatModeling.Model");
            this._tmData =  (TM7ThreatModel)serializer.Deserialize(stringReader);
        }

        private string PreProcessData(string fileContent)
        {
            return fileContent.Replace("a:", "").Replace("b:", "").Replace("i:", "").Replace("z:", "");
        }

        public object GetData(string category)
        {
            switch (category)
            {
                case "all":
                    return this._tmData;
                case "boundaries":
                    var boundaries = new List<List<string>>();
                    foreach(TM7DrawingSurfaceModel model in this._tmData.drawingSurfaceList.drawingSurfaceModel)
                    {
                        boundaries.Add((from b in model.borders.keyValueOfguidanyType where b.value.type == "BorderBoundary" select b.value.properties.anyType.FirstOrDefault().DisplayName).ToList());
                    }
                    return boundaries;
                default:
                    throw new InvalidDataException("Invalid category provided.");
            }
        }
    }
}
