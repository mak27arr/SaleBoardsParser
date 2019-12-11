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
using ScrapySharp.Html;

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
            ScrapingBrowser browser = new ScrapingBrowser();
            browser.Encoding = Encoding.UTF8;
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
                if(adv.ParentNode.GetClasses().Where(e => e == "promoted").Count() > 0)
                    ba.Type = BaseAdvertisementType.Top;
                else
                    ba.Type = BaseAdvertisementType.Usual;
                var adv_page_src = browser.NavigateToPage(new Uri(ba.Url));
                var adv_page = adv_page_src.Html.CssSelect(".offerdescription");
                ba.Location = adv_page.CssSelect(".show-map-link").FirstOrDefault().Descendants("strong").FirstOrDefault().InnerText;
                ba.Description = adv_page.CssSelect("#textContent").FirstOrDefault().InnerText;
                ba.AdvertisementVievCount = adv_page.CssSelect("#offerbottombar").Single().CssSelect("div.pdingtop10 > strong").FirstOrDefault().InnerText.StringToInt();

                var user_name = adv_page_src.Html.CssSelect(".offer-user__details").FirstOrDefault().CssSelect("a").FirstOrDefault().InnerText;
                var phone_rezalt = adv_page_src.FindLinks(By.Class("spoiler")).Single().Click();
                var user_phone = phone_rezalt.Html.CssSelect("ul.contact_methods").Single().CssSelect("strong.xx-large").Single().InnerText;
                var b = adv_page_src.Html.CssSelect("#offeractions").Single().CssSelect("ul.offer-sidebar__buttons.contact_methods").Single();
                var user_id = adv_page_src.Html.CssSelect("#offeractions").Single().CssSelect("ul.").Single().CssSelect("a.button-email").Single().Attributes.Where(e => e.Name == "href").Single().Value.Split("id=").Last();
                BaseUser bu = new BaseUser(user_id);
                bu.Name = user_name;
                bu.AddContact(ContactType.PhoneNumber, user_phone);
                ba.User = bu;
                ba.Id = adv_page.CssSelect(".offer-titlebox__details").Single().CssSelect("em").Single().CssSelect("small").Single().InnerText.StringToInt();
                //ba.CreationDate = ;
                
                
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
