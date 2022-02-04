using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
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
        public IActionResult Location(string location)
        {
            List<WeatherLocation> weatherLocationList = new List<WeatherLocation>();
            string strURL = "https://www.metaweather.com/api/location/search/?query=" + location;
            string url = strURL.Replace("\"", "");

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    weatherLocationList = JsonConvert.DeserializeObject<List<WeatherLocation>>(streamReader.ReadToEnd());
                }

                return Json(weatherLocationList);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult LocationDetail(int woeid)
        {
            List<WeatherLocationDetail> locationDetailList = new List<WeatherLocationDetail>();
            var today = DateTime.Now;

            string strURL = "https://www.metaweather.com/api/location/" + woeid + '/' + today.Year + '/' + today.Month + '/' + today.Day;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(strURL);

                httpWebRequest.ContentType = "text/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    locationDetailList = JsonConvert.DeserializeObject<List<WeatherLocationDetail>>(streamReader.ReadToEnd());
                }

                return Json(locationDetailList[0]);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
