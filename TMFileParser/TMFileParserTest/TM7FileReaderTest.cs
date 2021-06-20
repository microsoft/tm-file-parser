using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;
using TMFileParser;
using TMFileParser.Models;
using TMFileParser.Models.tm7;
using TMFileParser.Models.tb7;
using System.Collections.Generic;

namespace TMFileParserTest
{
    [TestClass]
    public class TM7FileReaderTest
    {
        private TM7FileReader reader;
        string tm7FilePath = @"Sample\sample1.tm7";

        [TestInitialize]
        public void Initialize()
        {
            reader = new TM7FileReader(new FileInfo(tm7FilePath));
        }

        [TestMethod]
        public void ReadTMFile_Test()
        {
            var tmData = (TM7ThreatModel)reader.GetData("all");
            Assert.AreEqual(tmData.version, "4.3");
        }

        [TestMethod]
        public void Get_Boundaries_Test()
        {
            var tmData = (List<List<string>>)reader.GetData("boundaries");
            Assert.AreEqual(tmData.FirstOrDefault().FirstOrDefault(), "Azure IaaS VM Trust Boundary");
        }

        [TestMethod]
        public void Get_Invalid_Category_Test()
        {
            Assert.ThrowsException<InvalidDataException>(() => reader.GetData("invalid"));
        }

    }
}
