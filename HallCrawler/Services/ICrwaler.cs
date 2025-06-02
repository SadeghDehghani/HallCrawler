using HallCrawler.Models;

namespace HallCrawler.Services
{
    public interface  ICrwaler
    {
        Task<ExportFindLik> GetGenerateLinkOnWebSite(MainWebCrawler dt, string linkUrl);
        Task<ExportFindLik> GetGeneratePaging(MainWebCrawler dt);
        Task<HallItem> GetHallLtem(MainWebCrawler dt, string linkUrl);
    }
}
