using System;
using System.Collections.Generic;
using System.Text;
using SaleBoardsParser.Parser.BaseInterface;
using SaleBoardsParser.Parser.BaseClasses;
using System.Linq;
using AngleSharp;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using SaleBoardsParser.Parser.Extension;

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
            ////var advertisements = document.QuerySelectorAll("div.offer-wrapper");
            //var advertisements = document.All.Where(e=>e.LocalName == "div" && e.ClassList.Contains("offer-wrapper"));
            //foreach(var itm in advertisements)
            //{
            //    Console.WriteLine(itm);
            //}
            //Console.WriteLine(document);
            ScrapingBrowser browser = new ScrapingBrowser();
            WebPage page = browser.NavigateToPage(new Uri(url));
            var advertisements = page.Html.CssSelect(".offer-wrapper");

            foreach(var adv in advertisements)
            {
                BaseAdvertisement ba = new BaseAdvertisement();
                var t = adv.CssSelect(".fleft").FirstOrDefault().Attributes.Where(e => e.Name == "src");
                ba.Img_url = adv.CssSelect(".fleft").FirstOrDefault().Attributes.Where(e=>e.Name== "src").FirstOrDefault().Value.Split(";").FirstOrDefault();
                ba.Url = adv.CssSelect(".linkWithHash").FirstOrDefault().Attributes.Where(e => e.Name == "href").FirstOrDefault().Value;
                ba.Name = adv.CssSelect(".title-cell").FirstOrDefault().Descendants("strong").FirstOrDefault().InnerText;
                ba.Price = adv.CssSelect(".price").FirstOrDefault().Descendants("strong").FirstOrDefault().InnerText.StringToDouble();
                ba.SectionName = adv.CssSelect(".breadcrumb").FirstOrDefault().InnerText.Split("»").Last();
                ba.Location = adv.CssSelect(".location-filled").FirstOrDefault().InnerText;
                if(adv.ParentNode.GetClasses().Where(e => e == "promoted").Count() > 0)
                    ba.Type = BaseAdvertisementType.Top;
                else
                    ba.Type = BaseAdvertisementType.Usual;

                WebPage page = browser.NavigateToPage(new Uri(Url));
                var advertisements = page.Html.CssSelect(".offer-wrapper");


                ba.User = ;
                ba.CreationDate = ;
                ba.Description = ;
                ba.AdvertisementVievCount = ;
                findedAdvertisement.Add(ba);
            }


            return null;
        }

        private string GetNextPageUrl(string url)
        {//?page=2
            var url_part = url.Split("?page=");
            if (url_part.Length > 1)
            {
                return url_part[0] + "?page=" + (int.Parse(url_part[1])+1);
            }
            else
            {
                return url_part[0] + "?page=2";
            }
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
