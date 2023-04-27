using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using TMFileParser;
using TMFileParser.Models.tm7;
using System.Collections.Generic;
using TMFileParser.Models.output;

namespace TMFileParserTest
{
    [TestClass]
    public class TM7FileReaderTest
    {
        private TM7FileReader reader;
        string tm7FilePath = @"Sample\sample1.tm7";
        string tm7EmptyFilePath = @"Sample\EmptyDiagram.tm7";
        string tm7NoDiagramFilePath = @"Sample\NoDiagram.tm7";
        string billionLaughsPath = @"Sample\BillionLaughs.tm7";
        string tm7ThreatsEnabledNullPath = @"Sample\ThreatsEnabledNull.tm7";

        [TestInitialize]
        public void Initialize() { }

        [TestMethod]
        public void ReadTMFile_Test()
        {
            reader = new TM7FileReader(new FileInfo(tm7FilePath));
            var tmData = (TM7All)reader.GetData("all");
            Assert.AreEqual(tmData.diagrams.FirstOrDefault().assets.FirstOrDefault().DisplayName, "Azure Cosmos DB");
        }

        [TestMethod]
        public void ReadEmptyTMFile_Test()
        {
            reader = new TM7FileReader(new FileInfo(tm7EmptyFilePath));
            var tmData = (TM7All)reader.GetData("all");
            Assert.AreEqual(tmData.diagrams.FirstOrDefault().assets.Count(), 0);
            Assert.AreEqual(tmData.diagrams.FirstOrDefault().boundaries.Count(), 0);
            Assert.AreEqual(tmData.diagrams.FirstOrDefault().connectors.Count(), 0);
            Assert.AreEqual(tmData.threats.Count(), 0);
        }

        [TestMethod]
        public void ReadNoDiagramTMFile_Test()
        {
            reader = new TM7FileReader(new FileInfo(tm7NoDiagramFilePath));
            var tmData = (TM7All)reader.GetData("all");
            Assert.AreEqual(tmData.diagrams, null);
            Assert.AreEqual(tmData.threats.Count(), 0);
        }

        [TestMethod]
        public void Get_Raw_Test()
        {
            reader = new TM7FileReader(new FileInfo(tm7FilePath));
            var tmData = (TM7ThreatModel)reader.GetData("raw");
            Assert.AreEqual(tmData.version, "4.3");
        }

        [TestMethod]
        public void NullThreatsGenerationEnabled_Test()
        {
            reader = new TM7FileReader(new FileInfo(tm7ThreatsEnabledNullPath));
            var tmData = (TM7ThreatModel)reader.GetData("raw");
            Assert.AreEqual(tmData.version, "4.3");
            Assert.AreEqual(tmData.threatGenerationEnabled, true);
        }

        [TestMethod]
        public void Get_Threats_Test()
        {
            reader = new TM7FileReader(new FileInfo(tm7FilePath));
            var tmData = (IEnumerable<object>)reader.GetData("threats");
            var diagramName = tmData.FirstOrDefault().GetType().GetProperty("diagram").GetValue(tmData.FirstOrDefault());
            Assert.AreEqual(diagramName, "Diagram 1");
        }

        [TestMethod]
        public void Get_Boundaries_Test()
        {
            reader = new TM7FileReader(new FileInfo(tm7FilePath));
            var tmData = (IEnumerable<object>)reader.GetData("boundaries");
            var diagramName = tmData.FirstOrDefault().GetType().GetProperty("diagram").GetValue(tmData.FirstOrDefault());
            Assert.AreEqual(diagramName, "Diagram 1");
        }

        [TestMethod]
        public void Get_Assets_Test()
        {
            reader = new TM7FileReader(new FileInfo(tm7FilePath));
            var tmData = (IEnumerable<object>)reader.GetData("assets");
            var diagramName = tmData.FirstOrDefault().GetType().GetProperty("diagram").GetValue(tmData.FirstOrDefault());
            Assert.AreEqual(diagramName, "Diagram 1");
        }

        [TestMethod]
        public void Get_Connectors_Test()
        {
            reader = new TM7FileReader(new FileInfo(tm7FilePath));
            var tmData = (IEnumerable<object>)reader.GetData("connectors");
            var diagramName = tmData.FirstOrDefault().GetType().GetProperty("diagram").GetValue(tmData.FirstOrDefault());
            Assert.AreEqual(diagramName, "Diagram 1");
        }

        [TestMethod]
        public void Get_Invalid_Category_Test()
        {
            reader = new TM7FileReader(new FileInfo(tm7FilePath));
            Assert.ThrowsException<InvalidDataException>(() => reader.GetData("invalid"));
        }

        [TestMethod]
        public void Billion_Laughs_Test()
        {
            Assert.ThrowsException<InvalidOperationException> (() => new TM7FileReader(new FileInfo(billionLaughsPath)));
        }

    }
}
