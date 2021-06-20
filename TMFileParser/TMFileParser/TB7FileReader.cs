using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TMFileParser.Interfaces;
using TMFileParser.Models.tb7;

namespace TMFileParser
{
    public class TB7FileReader : ITMFileReader
    {
        protected string _fileContent;
        private TB7KnowledgeBase _tmData;
        [ExcludeFromCodeCoverage]
        public TB7FileReader(FileInfo inputFile)
        {
            _fileContent = File.ReadAllText(inputFile.FullName);
            this.ReadTMFile();
        }

        private void ReadTMFile()
        {
            StringReader stringReader = new StringReader(_fileContent);
            XmlSerializer serializer = new XmlSerializer(typeof(TB7KnowledgeBase), new XmlRootAttribute("KnowledgeBase"));
            this._tmData = (TB7KnowledgeBase)serializer.Deserialize(stringReader);
        }

        public object GetData(string category)
        {
            switch (category)
            {
                case "all":
                    return this._tmData;
                default:
                    throw new InvalidDataException("Invalid category provided.");
            }
        }

    }
}
