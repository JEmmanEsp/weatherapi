using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using System.Net.Mime;
using Microsoft.Extensions.Options;
using Weatherapp.Application.Infrastructure.Services;
using Weatherapp.Infrastructure.Services.Settings;
using Weatherapp.Domain.Entities.CurrentModel;

namespace Weatherapp.Infrastructure.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        private readonly WeatherSettings _weatherSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        private HttpClient _httpClient;

        public CurrentWeatherService(IHttpClientFactory httpClientFactory, IOptions<WeatherSettings> options)
        {
            _weatherSettings = options.Value;
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient();
        }

        public async Task<CurrentResponse> GetCurrent(string location, string units)
        {
            var httpMessage = HttpUtils.GetRequestMessage(
                     $"{_weatherSettings.Url}{_weatherSettings.Current}{_weatherSettings.AccessKey}query={location}&units={units}",
                     HttpMethod.Get
                 );

            var result = await _httpClient.SendAsync(httpMessage);
            var response = await HttpUtils.MapHttpResponse<CurrentResponse>(result);
            return response;
        }
    }
}
