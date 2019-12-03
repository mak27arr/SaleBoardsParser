using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SaleBoardsParser.Parser.BaseInterface
{
    interface IBaseSaleBoards
    {
        public List<IAdvertisement> GetAdvertisement();
        public void UseHumanScan(bool UseHumanScan);
        public Task<List<IAdvertisement>> ScanPageAsync(string url);
        public List<IAdvertisement> ScanPage(string url);
        public Task<List<IAdvertisement>> SearchAsync(string param);
        public List<IAdvertisement> Search(string param);
    }
}
