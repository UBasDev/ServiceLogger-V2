using ServiceLogger.Services.Abstracts;
using System.Text.Json;

namespace ServiceLogger.Services.Concretes
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> getAllDataAsync()
        {            
            var responseFromApi = await _httpClient.GetAsync("dittoqqq");
            return await checkResponseSuccess(responseFromApi);
        }
        private async Task<string> checkResponseSuccess(HttpResponseMessage responseFromApi)
        {
            if (responseFromApi.IsSuccessStatusCode)
            {
                string convertingResponseToString = await responseFromApi.Content.ReadAsStringAsync();
                return convertingResponseToString;
            }
            else
            {
                return "";
            }
        }
    }
}
