using SaleBoardsParser.Parser.OLX;
using System;

namespace SaleBoardsParser
{
    class Program
    {
        static void Main(string[] args)
        {

            OLXParser op = new OLXParser();
            op.ScanPageAsync("https://www.olx.ua/list/q-%D0%BD%D0%BE%D1%83%D1%82%D0%B1%D1%83%D0%BA/").Wait();

            Console.WriteLine("Hello World!");
        }
    }
}
