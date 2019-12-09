using SaleBoardsParser.Parser.BaseInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleBoardsParser.Parser.BaseClasses
{
    class BaseAdvertisementType: IAdvertisementType
    {
        public string Value { get; protected set; }
        private BaseAdvertisementType(string value) { this.Value = value; }

        public static BaseAdvertisementType Usual { get { return new BaseAdvertisementType("Usual"); } }
        public static BaseAdvertisementType Top { get { return new BaseAdvertisementType("Top"); } }

        public override string ToString()
        {
            return this.Value;
        }
    }
}
