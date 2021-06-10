﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Text;
using System.Xml.Serialization;
using TMFileParser.Interfaces;
using TMFileParser.Models.tb7;

namespace TMFileParser
{
    public class TB7FileReader : ITMFileReader
    {
        private readonly IFileSystem _fileSystem;
        protected string _fileContent;
        [ExcludeFromCodeCoverage]
        public TB7FileReader(FileInfo inputFile) : this(new FileSystem(), inputFile) { }
        public TB7FileReader(FileSystem fileSystem, FileInfo inputFile)
        {
            _fileSystem = fileSystem;
            _fileContent = _fileSystem.File.ReadAllText(inputFile.FullName);
        }
        public object ReadTMFile()
        {
            StringReader stringReader = new StringReader(_fileContent);
            XmlSerializer serializer = new XmlSerializer(typeof(TB7KnowledgeBase), new XmlRootAttribute("KnowledgeBase"));
            return (TB7KnowledgeBase)serializer.Deserialize(stringReader);
        }

    }
}
