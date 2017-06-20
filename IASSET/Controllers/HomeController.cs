using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using IASSET.Models;

namespace IASSET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]

        public ActionResult GetCities(string countryName)
        {
            var list = new List<Cities>();
            if (!String.IsNullOrEmpty(countryName))
            {
                GWService1.GlobalWeatherSoapClient ws = new GWService1.GlobalWeatherSoapClient();

                var result = ws.GetCitiesByCountry(countryName);
                if (!String.IsNullOrEmpty(result) && result != "<NewDataSet />")
                {
                    XmlTextReader xtr = new XmlTextReader(new System.IO.StringReader(result));
                    var ds = new DataSet();
                    ds.ReadXml(xtr);
                    list = ds.Tables[0].AsEnumerable().Select(dataRow => new Cities { city = dataRow.Field<string>("city") }).ToList();

                }
                else
                {
                    result = "Data Not Found";
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetWeather(string countryName, string cityName)
        {
            var list = new List<Weather>();
            if (!String.IsNullOrEmpty(cityName))
            {
                GWService1.GlobalWeatherSoapClient ws = new GWService1.GlobalWeatherSoapClient();

                var result = ws.GetWeather(countryName, cityName);
                if (!String.IsNullOrEmpty(result) && result != "Data Not Found")
                {
                    XmlTextReader xtr = new XmlTextReader(new System.IO.StringReader(result));
                    var ds = new DataSet();
                    ds.ReadXml(xtr);
                    list = ds.Tables[0].AsEnumerable().Select(dataRow => new Weather
                    {
                        Time = dataRow.Field<string>("Time")
                        ,
                        Wind = dataRow.Field<string>("Wind")
                        ,
                        Visibility = dataRow.Field<string>("Visibility")
                        ,
                        SkyConditions = dataRow.Field<string>("SkyConditions")
                        ,
                        Temperatur = dataRow.Field<string>("Temperatur")
                        ,
                        DewPoint = dataRow.Field<string>("DewPoint")
                        ,
                        RelativeHumidity = dataRow.Field<string>("RelativeHumidity")
                        ,
                        Pressure = dataRow.Field<string>("Pressure")
                    }).ToList();

                }
                else
                {
                    result = "Data Not Found";

                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GetWeather2(string countryName, string cityName)
        {
            var list = new List<Weather>();
            if (!String.IsNullOrEmpty(cityName))
            {
                GWService1.GlobalWeatherSoapClient ws = new GWService1.GlobalWeatherSoapClient();

                var result = ws.GetWeather(countryName, cityName);
                if (!String.IsNullOrEmpty(result) && result != "Data Not Found")
                {
                    XmlTextReader xtr = new XmlTextReader(new System.IO.StringReader(result));
                    var ds = new DataSet();
                    ds.ReadXml(xtr);
                    list = ds.Tables[0].AsEnumerable().Select(dataRow => new Weather
                    {
                        Time = dataRow.Field<string>("Time")
                        ,
                        Wind = dataRow.Field<string>("Wind")
                        ,
                        Visibility = dataRow.Field<string>("Visibility")
                        ,
                        SkyConditions = dataRow.Field<string>("SkyConditions")
                        ,
                        Temperatur = dataRow.Field<string>("Temperatur")
                        ,
                        DewPoint = dataRow.Field<string>("DewPoint")
                        ,
                        RelativeHumidity = dataRow.Field<string>("RelativeHumidity")
                        ,
                        Pressure = dataRow.Field<string>("Pressure")
                    }).ToList();

                }
                else
                {
                    result = "Data Not Found";

                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);

        }
    }
}