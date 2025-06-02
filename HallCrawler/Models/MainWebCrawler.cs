namespace HallCrawler.Models
{
    public class MainWebCrawler
    {
        public int Id { get; set; }
        public string?  Name { get; set; }
        public string? Url { get; set; } 
        public string? CssHallsSelector { get; set; }
        public string? CssHallLinkSelector { get; set; }
        public string? CssTitleSelector { get; set; }
        public string? CssImageHallSelector { get; set; }
        public string? CssServicesSelector { get; set; }
        public string? CssPagnationSelector { get; set; }
        public string? CssPagnationLinkSelector { get; set; }
        public string? CssInformationSelector { get; set; }
        public string? CssCitySelector { get; set; }
        public string? UrlItem { get; set; }
      
    }
}
