using Shop.Core.Dto.AccuWeatherDtos;
using Nancy.Json;
using Shop.Core.ServiceInterface;
using System.Net;
using Nancy.Responses;

namespace Shop.ApplicationServices.Services
{
    public class AccuWeatherForecastServices : IAccuWeatherForecastServices
    {
        public async Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto)
        {
            string apiKey = "hxoegsNkWJ2nRk3vP5t9WtM2ujEtFwbQ"; // 
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={apiKey}&q={dto.City}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                AccuWeatherResponseRootDto weatherResult = new JavaScriptSerializer().Deserialize<List<AccuWeatherResponseRootDto>>(json).FirstOrDefault();
                dto.Key = weatherResult.Key;
                string url2 = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{dto.Key}?apikey={apiKey}";
                json = client.DownloadString(url2);
                AccuWeatherForecastResponseRootDto forecastResult = new JavaScriptSerializer().Deserialize<AccuWeatherForecastResponseRootDto>(json);
                dto.TemperatureMin = forecastResult.DailyForecasts.FirstOrDefault().Temperature.Minimum.Value;
                if (forecastResult.DailyForecasts.FirstOrDefault()?.Temperature.Minimum.Unit == "F")
                    dto.TemperatureMin = (dto.TemperatureMin - 32) * 5 / 9;

                dto.TemperatureMax = forecastResult.DailyForecasts.FirstOrDefault().Temperature.Maximum.Value;

                if (forecastResult.DailyForecasts.FirstOrDefault()?.Temperature.Maximum.Unit == "F")
                    dto.TemperatureMax = (dto.TemperatureMin - 32) * 5 / 9;

                dto.Link = forecastResult.DailyForecasts.FirstOrDefault().Link;
            }

            return dto;
        }
    }
}