using System;
using System.Collections.Generic;
using System.Text;

namespace SaleBoardsParser.Parser.BaseInterface
{
    interface IBaseSaleBoards
    {
        public List<IAdvertisement> GetAdvertisement();
        public void UseHumanScan(bool UseHumanScan);
        public void ScanPageAsync(string url);
        public List<IAdvertisement> ScanPage(string url);
        public void SearchAsync(string param);
        public List<IAdvertisement> Search(string param);
    }
}
