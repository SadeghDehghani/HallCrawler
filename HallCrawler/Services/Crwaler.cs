using HallCrawler.Models;
using HtmlAgilityPack;

namespace HallCrawler.Services
{

    public class ExportFindLik
    {

        public List<string>? Link { get; set; }
        public List<string>? PageLinks { get; set; }

    }
    public class Crwaler : ICrwaler
    {
        public async Task<ExportFindLik> GetGenerateLinkOnWebSite(MainWebCrawler dt, string linkUrl)
        {

            var web = new HtmlWeb();

            List<string> Links = new List<string>();
            List<string> PageLinks = new List<string>();
            ExportFindLik exportFindLik = new ExportFindLik();

            try
            {
                var document = await web.LoadFromWebAsync(url: linkUrl);
                var classMain = document.DocumentNode.QuerySelectorAll(cssSelector: dt.CssHallsSelector);
                foreach (var item in classMain)
                {
                    if (item != null && classMain.Count > 0)
                    {
                        var AHref = item.QuerySelector(cssSelector: dt.CssHallLinkSelector);
                        var Href = AHref.Attributes["href"].Value;
                        Links.Add(Href);
                    }
                }
                exportFindLik.Link = Links;
                return exportFindLik;
            }
            catch (Exception ex)
            {


            }


            return exportFindLik;

        }
        public async Task<ExportFindLik> GetGeneratePaging(MainWebCrawler dt)
        {
            var web = new HtmlWeb();

            List<string> Links = new List<string>();
            List<string> PageLinks = new List<string>();
            ExportFindLik exportFindLik = new ExportFindLik();

            try
            {
                var document = await web.LoadFromWebAsync(url: dt.Url);
                var classMainPaging = document.DocumentNode.QuerySelectorAll(cssSelector: dt.CssPagnationSelector);

                if (classMainPaging.Count>0)
                {
                    foreach (var item in classMainPaging)
                    {
                        if (item != null && classMainPaging.Count > 0)
                        {
                            var AHref = item.QuerySelector(cssSelector: dt.CssPagnationLinkSelector);
                            var Href = dt.Url + AHref.Attributes[name: "href"].Value;
                            PageLinks.Add(Href);
                        }
                    }
                }

             
                var first = PageLinks.Count>0? PageLinks.FirstOrDefault() : dt.Url+"?pa=0";
                var end = PageLinks .Count>0? PageLinks.LastOrDefault(): dt.Url + "?pa=0";

                var output = end.Split(separator: "=");
                var endPage = output.Length>1 ? Convert.ToInt32(output[1].ToString()) :0 ;

                PageLinks.Clear();

                for (int i = 0; i <= endPage; i++)
                {
                    string link = output[0].ToString() + "=" + i.ToString();
                    PageLinks.Add(link);
                }
                exportFindLik.PageLinks = PageLinks;
                return exportFindLik;
            }
            catch (Exception ex)
            {


            }


            return exportFindLik;
        }
        public async Task<HallItem> GetHallLtem(MainWebCrawler dt, string linkUrl)
        {
            var web = new HtmlWeb();
            HallItem hallItem = new HallItem();

            string Url = dt.UrlItem+ linkUrl;

            try
            {
                var document = await web.LoadFromWebAsync(url: Url);



                var city = document.DocumentNode.QuerySelectorAll(cssSelector: dt.CssCitySelector);

                var optinCity=city[0].QuerySelectorAll("option");

                foreach (var item in optinCity)
                {
                    if (item.Attributes["selected"] != null)
                    {
                        hallItem.City = item.InnerText;
                    }
                }

                var title = document.DocumentNode.QuerySelector(cssSelector: dt.CssTitleSelector).InnerText;


                var services = document.DocumentNode.QuerySelectorAll(cssSelector: dt.CssServicesSelector);
                foreach (var serv in services)
                {
                    var serviceItem = serv.InnerText;
                   // 
                    hallItem.Services = hallItem.Services + serviceItem + ",";
                }
                var Infos = document.DocumentNode.QuerySelectorAll(cssSelector: dt.CssInformationSelector);
                var array=Infos.ToArray();

                if (array.Count()>0)
                {
                    if (array.Length >= 2)
                    {
                        hallItem.Manager = array[1].InnerText;
                    }

                    if (array.Length >= 3)
                    {
                        hallItem.Tel = array[2].InnerText;
                    }
                    if (array.Length >= 4)
                    {
                        hallItem.CellPhone = array[3].InnerText;
                    }
                    if (array.Length >= 5)
                    {
                        hallItem.Address = array[4].InnerText;
                    }
                    if (array.Length>=7)
                    {

                        hallItem.Capacity = array[6].InnerText;
                    }

                }

        
                hallItem.Title = title;


                //Images
                string imageItem = "";
                var images = document.DocumentNode.QuerySelectorAll(cssSelector: dt.CssImageHallSelector);

                foreach(var img in images)
                {
                     imageItem = "https://esfahan.banktalar.com" +  img.Attributes["href"].Value;
                }
                //
                hallItem.Image=imageItem;

                return hallItem;
            }
            catch (Exception ex)
            {


            }


            return hallItem;

        }
    }

}


