using System;
using System.Collections.Generic;
using System.Text;

namespace SaleBoardsParser.Parser.Browser
{
    public class JavascriptException : Exception
    {
        public JavascriptException(string message) : base(message) { }
    }
}
