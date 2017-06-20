using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IASSET.Models
{
    public class Weather
    {
        public string Time { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyConditions { get; set; }
        public string Temperatur { get; set; }
        public string DewPoint { get; set; }
        public string RelativeHumidity { get; set; }
        public string Pressure { get; set; }
    }
}