using SaleBoardsParser.Parser.BaseInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaleBoardsParser.Parser.BaseClasses
{
    class BaseAdvertisement : IAdvertisement
    {
        private double price;
        public double Price { 
            get { return price; } 
            set {
                if (value >= 0)
                    price = value;
                else
                    price = 0;
            } }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Img_url { get; set; }
        public string SectionName { get; set; }
        public IAdvertisementType Type { get; set; }
        public IUser User { get; set; }
        public int AdvertisementVievCount { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
    }
}
