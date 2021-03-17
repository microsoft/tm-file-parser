using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Xml;
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
                TM7ThreatModel obj;
                using (TextReader textReader = new StringReader(processedFileContent))
                {
                    using (XmlTextReader reader = new XmlTextReader(textReader))
                    {
                        reader.Namespaces = false;
                        XmlSerializer aserializer = new XmlSerializer(typeof(TM7ThreatModel));
                        obj = (TM7ThreatModel)aserializer.Deserialize(reader);
                    }
                }          
                return obj;
            }
            else
            {
                TB7KnowledgeBase obj;
                using (TextReader textReader = new StringReader(processedFileContent))
                {
                    using (XmlTextReader reader = new XmlTextReader(textReader))
                    {
                        reader.Namespaces = false;
                        XmlSerializer aserializer = new XmlSerializer(typeof(TB7KnowledgeBase));
                        obj = (TB7KnowledgeBase)aserializer.Deserialize(reader);
                    }
                }
                return obj;
            }
        }

        private string PreProcess(string fileContent, string fileExtension)
        {
            if (fileExtension == ".tm7")
            {
                //Add steps to preprocess the file if required
            }
            return fileContent;
        }
        
    }
}
