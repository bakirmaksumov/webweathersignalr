using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class WeatherForecastViewModel
    {
        public string CityName { get; set; }
        public string CountryName { get; set; }
        //Geographical coordinates (latitude)
        public string Lat { get; set; }
        //Geographical coordinates (longitude)
        public string Lon { get; set; }
        public string DescriptionWeather { get; set; }
        //weather temprature
        public string Temprature { get; set; }
        //temp_min and temp_max are optional parameters mean min / max
        public string TempMax { get; set; }
        public string TempMin { get; set; }
        //Humidity, %
        public string Humidity { get; set; }
        //Temperature. This temperature parameter accounts for the human perception of weather
        public string TempFeels { get; set; }
        public string WeatherPic { get; set; }

        public List<string> CountryNameList { get; set; }

        public WeatherForecastViewModel getWeatherItem(WeatherForecastViewModel resultModel, 
            RootObject weatherInfo)
        {
            resultModel.CountryName = weatherInfo.sys.country;
            resultModel.CityName = weatherInfo.name;
            resultModel.Lat = Convert.ToString(weatherInfo.coord.lat);
            resultModel.Lon = Convert.ToString(weatherInfo.coord.lon);
            resultModel.DescriptionWeather = weatherInfo.weather[0].description;
            resultModel.Humidity = Convert.ToString(weatherInfo.main.humidity);
            resultModel.TempFeels = Convert.ToString(weatherInfo.main.feels_like);
            resultModel.TempMax = Convert.ToString(weatherInfo.main.temp_max);
            resultModel.TempMin = Convert.ToString(weatherInfo.main.temp_min);
            resultModel.Temprature = Convert.ToString(weatherInfo.main.temp);
            resultModel.WeatherPic = weatherInfo.weather[0].icon;

            return resultModel;
        }

    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public int temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
    public class RootObject
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}  
  