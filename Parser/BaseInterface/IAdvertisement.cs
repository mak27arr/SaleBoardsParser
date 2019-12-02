﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SaleBoardsParser.Parser.BaseInterface
{
    interface IAdvertisement
    {
        double Price { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string url { get; set; }
        string SectionName { get; set; }
        int AdvertisementVievCount { get; set; }
        IAdvertisementType Type { get; set; }
        IUser User { get; set; }

    }
}
