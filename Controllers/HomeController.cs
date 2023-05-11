using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SaveSites()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveSites(Site site)
        {
            FirebaseContext context = new FirebaseContext();

            var sitesRef = context.Client.Child("sites");
            sitesRef.PostAsync(new Site
            {
                SiteId = site.SiteId,
                SiteAddress = site.SiteAddress,
                Latitude = site.Latitude,
                Longitude = site.Longitude
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetSites()
        {
            FirebaseClient _firebaseClient = new FirebaseClient("https://testpro-8e054-default-rtdb.firebaseio.com/");

            var sites = await _firebaseClient.Child("sites").OnceAsync<Site>();
            List<Site> siteList = new List<Site>();
            foreach (var siteSnapshot in sites)
            {
                Site site = siteSnapshot.Object;
                siteList.Add(site);
            }
            return View(siteList);
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
