using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TMFileParser;
using TMFileParser.Models.tb7;

namespace TMFileParserTest
{
    [TestClass]
    public class TB7FileReaderTest
    {
        string tb7FilePath = @"Sample\MedicalDeviceTemplate.tb7";
        string billionLaughsPath = @"Sample\BillionLaughs.tb7";
        private TB7FileReader reader;
        [TestInitialize]
        public void Initialize()
        {
            reader = new TB7FileReader(new FileInfo(tb7FilePath));
        }

        [TestMethod]
        public void Get_All_Test()
        {
            var kbData = (TB7KnowledgeBase)reader.GetData("all");
        }

        [TestMethod]
        public void Get_Invalid_Category_Test()
        {
            Assert.ThrowsException<InvalidDataException>(() => reader.GetData("invalid"));
        }

        [TestMethod]
        public void Billion_Laughs_Test()
        {
            Assert.ThrowsException<InvalidOperationException>(() => new TB7FileReader(new FileInfo(billionLaughsPath)));
        }
    }
}
