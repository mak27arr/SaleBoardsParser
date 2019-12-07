using System;
using System.Collections.Generic;
using System.Text;
using SaleBoardsParser.Parser.BaseInterface;
using SaleBoardsParser.Parser.BaseClasses;
using System.Linq;
using AngleSharp;
using System.Threading.Tasks;
using SaleBoardsParser.Parser.Browser;
using ScrapySharp.Network;
using ScrapySharp.Extensions;

namespace SaleBoardsParser.Parser.OLX
{
    class OLXParser : IBaseSaleBoards
    {
        private List<BaseAdvertisement> findedAdvertisement = new List<BaseAdvertisement>();

        public List<IAdvertisement> GetAdvertisement()
        {
            return findedAdvertisement.Select(e=>(IAdvertisement)e).ToList();
        }

        public List<IAdvertisement> ScanPage(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IAdvertisement>> ScanPageAsync(string url)
        {
            //var config = Configuration.Default.WithDefaultLoader();
            //var context = BrowsingContext.New(config);
            //var document = await context.OpenAsync(url);
            //var advertisements = document.QuerySelectorAll("div.offer-wrapper");
            //var advertisements = document.All.Where(e=>e.LocalName == "div" && e.ClassList.Contains("offer-wrapper"));
            //foreach(var itm in advertisements)
            //{
            //    Console.WriteLine(itm);
            //}
            //Console.WriteLine(document);
            //CefSharpWrapper wrapper = new CefSharpWrapper();
            //wrapper.InitializeBrowser();
            ScrapingBrowser browser = new ScrapingBrowser();
            WebPage page = browser.NavigateToPage(new Uri(url));
            var advertisements = page.Html.CssSelect(".offer-wrapper");
            return null;
        }

        public List<IAdvertisement> Search(string param)
        {
            throw new NotImplementedException();
        }

        public Task<List<IAdvertisement>> SearchAsync(string param)
        {
            throw new NotImplementedException();
        }

        public void UseHumanScan(bool UseHumanScan)
        {
            throw new NotImplementedException();
        }
    }
}
