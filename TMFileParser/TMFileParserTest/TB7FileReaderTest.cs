using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using TMFileParser;
using TMFileParser.Models;
using TMFileParser.Models.tm7;
using TMFileParser.Models.tb7;
using System.IO.Abstractions.TestingHelpers;

namespace TMFileParserTest
{
    [TestClass]
    public class TB7FileReaderTest
    {
        private TB7FileReader reader;
        [TestInitialize]
        public void Initialize()
        {
            var mockFileSystem = new MockFileSystem();
            var mockKBFile = new MockFileData("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<KnowledgeBase xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Manifest name=\"Sample KB File\" id=\"00000000-0000-0000-0000-000000000000\" version=\"1.1.1.1\" author=\"TM Team\" /><ThreatMetaData>  <IsPriorityUsed>true</IsPriorityUsed>  <IsStatusUsed>true</IsStatusUsed>  <PropertiesMetaData>    <ThreatMetaDatum>      <Name>Title</Name>      <Label>Title</Label>      <HideFromUI>false</HideFromUI>      <Values>        <Value />      </Values>      <Id>00000000-0000-0000-0000-000000000000</Id>      <AttributeType>0</AttributeType>    </ThreatMetaDatum>    <ThreatMetaDatum>      <Name>ThreatCategory</Name>      <Label>Category</Label>      <HideFromUI>false</HideFromUI>      <AttributeType>0</AttributeType>    </ThreatMetaDatum>  </PropertiesMetaData></ThreatMetaData><GenericElements>  <ElementType><Name>Generic Sample Element</Name><ID>GE.EI</ID>    <Description>Generic Sample Element.</Description>    <ParentElement>ROOT</ParentElement>    <Image>sample-image</Image>    <Hidden>false</Hidden>    <Representation>Rectangle</Representation>    <StrokeThickness>0</StrokeThickness>    <ImageLocation>Lower right of stencil</ImageLocation>    <Attributes>      <Attribute>        <Id>00000000-0000-0000-0000-000000000000</Id>        <IsInherited>false</IsInherited>        <Name>sample-attribute</Name>        <DisplayName>Sample Attribute</DisplayName>        <Mode>Dynamic</Mode>        <Type>List</Type>        <Inheritance>Virtual</Inheritance>        <AttributeValues>          <Value>Not Applicable</Value>          <Value>No</Value>          <Value>Yes</Value>        </AttributeValues>      </Attribute>    </Attributes>  </ElementType></GenericElements>\r\n</KnowledgeBase>\r\n");
            mockFileSystem.AddFile(@"C:\tmfiles\kb.tb7", mockKBFile);
            reader = new TB7FileReader(mockFileSystem, new FileInfo(@"C:\tmfiles\kb.tb7"));
        }

        [TestMethod]
        public void ReadTMFile_Test()
        {
            var kbData = (TB7KnowledgeBase)reader.ReadTMFile();
        }
    }
}
