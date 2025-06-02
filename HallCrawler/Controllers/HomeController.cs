using System.Diagnostics;
using HallCrawler.Models;
using HallCrawler.Services;
using Microsoft.AspNetCore.Mvc;

namespace HallCrawler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _db;
        private ICrwaler _crwaler;


        public HomeController(ILogger<HomeController> logger, ICrwaler crwaler, Context db)
        {
            _logger = logger;
            _crwaler = crwaler;
            _db = db;
        }

        public IActionResult Index(string? id, string? term)
        {
            ViewBag.SelectedHall = "";

            if (!string.IsNullOrEmpty(term))
            {
                var list = _db.HallItems.Where(c =>
                            c.Title.Contains(term) || c.CellPhone.Contains(term) || c.Address.Contains(term)
                                            || c.Manager.Contains(term)).ToList();

                var cities = _db.HallItems.ToList().Select(x => x.City).Distinct().ToList();
                ViewBag.Cities = cities;
                return View(list);
            }

            if (id == null)
            {
                var list = new List<HallItem>();
                var cities = _db.HallItems.ToList().Select(x => x.City).Distinct().ToList();
                ViewBag.Cities = cities;
                return View(list);
            }
            else if (id != null && id == "0")
            {
                var list = _db.HallItems.ToList();
                var cities = _db.HallItems.ToList().Select(x => x.City).Distinct().ToList();
                ViewBag.Cities = cities;
                return View(list);
            }

            else
            {

                var citiesItems = _db.HallItems.ToList().Select(x => x.City).Distinct().ToList();
                ViewBag.Cities = citiesItems;
                var selected = _db.HallItems.Where(c => c.City == id).ToList();

                ViewBag.SelectedHall = id;
                return View(selected);
            }



        }

        public async Task<IActionResult> FetchData()
        {
            MainWebCrawler? first = _db.MainWebCrawlers.FirstOrDefault();

            var TalarListPaging = await _crwaler.GetGeneratePaging(first);


            foreach (var item in TalarListPaging.PageLinks)
            {
                var TalarList = await _crwaler.GetGenerateLinkOnWebSite(first, item);

                foreach (var talar in TalarList.Link)
                {

                    HallItem hallItem = new HallItem();

                    hallItem = await _crwaler.GetHallLtem(first, talar);

                    var check = _db.HallItems.Where(c => c.Title == hallItem.Title).FirstOrDefault();

                    if (check == null)
                    {

                        _db.HallItems.Add(hallItem);
                        await _db.SaveChangesAsync();

                    }



                }

            }
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
