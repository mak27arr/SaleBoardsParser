using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleBoardsParser.Parser.Extension
{
    public static class StringExtension
    {
        public static double StringToDouble(this string str,char separator = ',')
        {  
                var intMatch = str.Where(сh => (Char.IsDigit(сh) || сh == separator));
                double rezult = 0;
                double.TryParse(string.Concat(intMatch), out rezult);
                return rezult;        
        }
    }
}
