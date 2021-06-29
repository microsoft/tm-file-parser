using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMFileParser.Interfaces;

namespace TMFileParser
{
    public class Parser
    {
        private FileInfo _inputFile;
        public ITMFileReader _reader;

        public Parser(FileInfo inputFile)
        {
            this._inputFile = inputFile;
            SelectReader();
        }

        private void SelectReader()
        {
            switch (_inputFile.Extension.ToLower())
            {
                case ".tm7":
                    _reader = _reader ?? new TM7FileReader(this._inputFile);
                    break;
                case ".tb7":
                    _reader = _reader ?? new TB7FileReader(this._inputFile);
                    break;
                default:
                    throw new NotSupportedException("Invalid File Format/Path");
            }
        }

        public object GetData(string category)
        {
            category = category.ToLower();
            return _reader.GetData(category);
        }
    }
}
