﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TMFileParser.Interfaces
{
    public interface ITMFileReader
    {
        public object ReadTMFile(string filePath);
    }
}
