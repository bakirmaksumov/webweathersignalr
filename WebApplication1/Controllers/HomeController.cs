using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
            var modelView = new WeatherForecastViewModel();
            modelView.CountryNameList = GetAllCountryList();
            return View(modelView);
        }
       [HttpPost]
        public String GetWeatherDetail(string city)
        {
            //my API key
            string apiKey = "74beaf6bf72f7a62583dd75f89104d35";
            //parameters
            string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&cnt=1&appid={1}", city, apiKey);
            using (var client = new WebClient())
            {
                string resultJson = client.DownloadString(url);
                RootObject weatherInfo = (new JavaScriptSerializer()).Deserialize<RootObject>(resultJson);
                var resultModel = new WeatherForecastViewModel();
                var resut = resultModel.getWeatherItem(resultModel, weatherInfo);
                var jsonString = new JavaScriptSerializer().Serialize(resut);
                return jsonString;
            }
           // return View();

        }
        [HttpPost]
        public int Add(int number1, int numer2)
        {
            return number1 + numer2;
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
        //get cuntry list
        private List<string> GetAllCountryList()
        {
            var cultureLst = new List<string>();
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (var cultureItems in getCultureInfo)
            {
                var region = new RegionInfo(cultureItems.LCID);
                if (!(cultureLst.Contains(region.EnglishName)))
                { cultureLst.Add(region.EnglishName); }
            }
            cultureLst.Sort();
            return cultureLst;
        }
    }
}
