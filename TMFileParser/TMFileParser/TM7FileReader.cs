using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Text;
using System.Xml.Serialization;
using TMFileParser.Interfaces;
using TMFileParser.Models.tm7;

namespace TMFileParser
{
    public class TM7FileReader : ITMFileReader
    {
        private readonly IFileSystem _fileSystem;
        protected string _fileContent;
        [ExcludeFromCodeCoverage]
        public TM7FileReader(string filePath) : this(new FileSystem(), filePath) { }
        public TM7FileReader(IFileSystem fileSystem, string filePath) {
            _fileSystem = fileSystem;
            _fileContent = _fileSystem.File.ReadAllText(filePath);
        }
        public object ReadTMFile(string filePath)
        {
            var processedFileContent = PreProcess(_fileContent);
            StringReader stringReader = new StringReader(processedFileContent);
            XmlSerializer serializer = new XmlSerializer(typeof(TM7ThreatModel), "http://schemas.datacontract.org/2004/07/ThreatModeling.Model");
            return (TM7ThreatModel)serializer.Deserialize(stringReader);
        }

        private string PreProcess(string fileContent)
        {
            //fileContent = fileContent.Replace("a:", "");
            //fileContent = fileContent.Replace("b:", "");
            //fileContent = fileContent.Replace("i:", "");
            //fileContent = fileContent.Replace("z:", "");
            return fileContent;
        }
    }
}
