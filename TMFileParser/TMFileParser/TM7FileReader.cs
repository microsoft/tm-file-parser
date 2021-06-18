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
        public TM7FileReader(FileInfo inputFile) : this(new FileSystem(), inputFile) { }
        public TM7FileReader(IFileSystem fileSystem, FileInfo inputFile) {
            _fileSystem = fileSystem;
            _fileContent = _fileSystem.File.ReadAllText(inputFile.FullName);
        }
        public object ReadTMFile()
        {
            StringReader stringReader = new StringReader(this.PreProcessData(_fileContent));
            XmlSerializer serializer = new XmlSerializer(typeof(TM7ThreatModel), "http://schemas.datacontract.org/2004/07/ThreatModeling.Model");
            return (TM7ThreatModel)serializer.Deserialize(stringReader);
        }

        private string PreProcessData(string fileContent)
        {
            return fileContent.Replace("a:", "").Replace("b:", "").Replace("i:","").Replace("z:","");
        }
    }
}
