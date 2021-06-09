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
using TMFileParser.Interfaces;

namespace TMFileParserTest
{
    [TestClass]
    public class ParserTest
    {

        Parser parser;
        Mock<TM7FileReader> tm7reader;
        Mock<TB7FileReader> tb7reader;
        string tm7filePath = @"C:\tmfiles\tm.tm7";
        string tb7filePath = @"C:\tmfiles\kb.tb7";
        [TestInitialize]
        public void Initialize()
        {
            TM7ThreatModel tmOutput = new TM7ThreatModel();
            tmOutput.version = "1.0";
            tm7reader = new Mock<TM7FileReader>(tm7filePath);
            tm7reader.Setup(x => x.ReadTMFile(tm7filePath)).Returns(tmOutput);
            TB7KnowledgeBase tbOutput = new TB7KnowledgeBase();
            tbOutput.manifest.version = "1.0";
            tb7reader = new Mock<TB7FileReader>(tb7filePath);
            tb7reader.Setup(x => x.ReadTMFile(tb7filePath)).Returns(tbOutput);
        }

        [TestMethod]
        public void Parse_TM7File()
        {
            var moq = new Mock<ITMFileReader>(tm7filePath);
            parser = new Parser(@"C:/tmfiles/tm.tm7");
            parser.ReadFile();

        }

        //[TestMethod]
        //public void Parse_TB7File()
        //{
        //    this.parser = new Parser(tb7filePath);
        //    parser.ReadFile();

        //}

        //[TestMethod]
        //public void Parse_With_Invalid_Extension()
        //{
        //    this.parser = new Parser(@"C:\tmfiles\tm.exe");
        //    Assert.ThrowsException<NotSupportedException>(() => parser.ReadFile());
        //}

        //[TestMethod]
        //public void Parse_With_Invalid_Input()
        //{
        //    this.parser = new Parser("Sample Text");
        //    Assert.ThrowsException<NotSupportedException>(() => parser.ReadFile());
        //}

        //[TestMethod]
        //public void Read_With_Null()
        //{
        //    this.parser = new Parser(null);
        //    Assert.ThrowsException<NotSupportedException>(() => parser.ReadFile());
        //}
    }
}
