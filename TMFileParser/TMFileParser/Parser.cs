using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMFileParser.Interfaces;

namespace TMFileParser
{
    public class Parser
    {
        private string _filePath;
        private string _fileExtension;
        private ITMFileReader _reader;

        public Parser(string filePath)
        {
            this._filePath = filePath;
            SetFileExtension();
            SelectReader();
        }

        private void SelectReader()
        {
            switch (this._fileExtension)
            {
                case ".tm7":
                    _reader = _reader??new TM7FileReader(this._filePath);
                    break;
                case ".tb7":
                    _reader = new TB7FileReader(this._filePath);
                    break;
                default:
                    throw new NotSupportedException("Invalid File Format/Path");
            }
        }

        public object ReadFile()
        {
            return _reader.ReadTMFile(_filePath);

        }

        private void SetFileExtension()
        {
            _fileExtension = Path.GetExtension(_filePath);
        }
    }
}
