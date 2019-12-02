using System;
using System.Collections.Generic;
using System.Text;
using SaleBoardsParser.Parser.BaseInterface;
using SaleBoardsParser.Parser.BaseClasses;

namespace SaleBoardsParser.Parser.OLX
{
    class OLXParser : IBaseSaleBoards
    {
        private List<BaseAdvertisement> findedAdvertisement = new List<BaseAdvertisement>();

        public List<IAdvertisement> GetAdvertisement()
        {
            throw new NotImplementedException();
        }

        public List<IAdvertisement> ScanPage(string url)
        {
            throw new NotImplementedException();
        }

        public void ScanPageAsync(string url)
        {
            throw new NotImplementedException();
        }

        public List<IAdvertisement> Search(string param)
        {
            throw new NotImplementedException();
        }

        public void SearchAsync(string param)
        {
            throw new NotImplementedException();
        }

        public void UseHumanScan(bool UseHumanScan)
        {
            throw new NotImplementedException();
        }
    }
}
