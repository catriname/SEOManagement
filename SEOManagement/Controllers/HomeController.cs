using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SEOManagement.Models;
using SEOManagement.Services;
using System.Diagnostics;

namespace SEOManagement.Controllers
{
    public class HomeController : Controller
    {
        private SEOService seoService = new SEOService();

        public IActionResult Index()
        {
            ViewBag.SEO = seoService.Get(Request.GetDisplayUrl());
            return View();
        }

        public IActionResult About()
        {
            ViewBag.SEO = seoService.Get(Request.GetDisplayUrl());
            return View();
        }
        public IActionResult SamplePage1()
        {
            ViewBag.SEO = seoService.Get(Request.GetDisplayUrl());
            return View();
        }
        public IActionResult SamplePage2()
        {
            ViewBag.SEO = seoService.Get(Request.GetDisplayUrl());
            return View();
        }
        public IActionResult Privacy()
        {
            ViewBag.SEO = seoService.Get(Request.GetDisplayUrl());
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
