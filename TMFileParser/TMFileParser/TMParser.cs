using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Xml.Serialization;
using TMFileParser.Models.tb7;
using TMFileParser.Models.tm7;

namespace TMFileParser
{
    public class TMParser
    {
        private readonly IFileSystem _fileSystem;

        [ExcludeFromCodeCoverage]
        public TMParser() : this(new FileSystem()) { }

        public TMParser(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public object ReadV7(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException(String.Format("Invalid or Empty file path."));
            }else
            {
                string fileExtension = Path.GetExtension(filePath);
                if (fileExtension != ".tb7" && fileExtension != ".tm7")
                {
                    throw new Exception(String.Format("Invalid file format."));
                }
                else
                {
                    string fileContent = _fileSystem.File.ReadAllText(filePath);
                    var processedFileContent = this.PreProcess(fileContent, fileExtension);
                    return ReadContent(processedFileContent, fileExtension);
                }
            }

        }

        private object ReadContent(string processedFileContent, string fileExtension)
        {
            StringReader stringReader = new StringReader(processedFileContent);

            if (fileExtension == ".tm7")
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TM7ThreatModel), new XmlRootAttribute("ThreatModel"));
                return (TM7ThreatModel)serializer.Deserialize(stringReader);

            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TB7KnowledgeBase), new XmlRootAttribute("KnowledgeBase"));
                return (TB7KnowledgeBase)serializer.Deserialize(stringReader);
            }
        }

        private string PreProcess(string fileContent, string fileExtension)
        {
            if(fileExtension == ".tm7")
            {
                string tmNameSpace = "xmlns=\"http://schemas.datacontract.org/2004/07/ThreatModeling.Model\"";
                fileContent = fileContent.Replace(tmNameSpace, "");
            }
            return fileContent;
        }
        
    }
}
