using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TMFileParser;
using TMFileParser.Models.tm7;


namespace TMFileParserTest
{
    [TestClass]
    public class ParserTest
    {

        Parser parser;
        string tm7FilePath = @"Sample\sample1.tm7";
        string jsonFilePath = @"Sample\sample1.json";
        string tb7FilePath = @"Sample\MedicalDeviceTemplate.tb7";
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void Parse_TM7File()
        {
            parser = new Parser(new FileInfo(tm7FilePath));
            var parserType = parser._reader.GetType();
            Assert.AreEqual(parserType.Name, "TM7FileReader");
        }

        [TestMethod]
        public void Parse_TB7File()
        {
            parser = new Parser(new FileInfo(tb7FilePath));
            var parserType = parser._reader.GetType();
            Assert.AreEqual(parserType.Name, "TB7FileReader");
        }

        [TestMethod]
        public void Parse_Invalid_File_Format()
        {
            Assert.ThrowsException<NotSupportedException>(() => new Parser(new FileInfo(jsonFilePath)));
        }

        [TestMethod]
        public void Parser_Check_Data()
        {
            parser = new Parser(new FileInfo(tm7FilePath));
            var tmData = (TM7ThreatModel)parser.GetData("All");
            Assert.AreEqual(tmData.version, "4.3");
        }
    }
}
