using Giphy.API.Models;
using Giphy.API.Services.IServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Giphy.API.Services
{
    public class WebApiCaller : IWebApiCaller
    {
        protected HttpClient _httpClient;
        public WebApiCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)  
        {
            try
            {
                var message = new HttpRequestMessage(apiRequest.ApiType,apiRequest.Url);
                message.Headers.Add("Accept", "application/json");

                if (apiRequest.Data != null)
                {
                    message.Content = JsonContent.Create(apiRequest.Data);
                }
                
                var apiResponse = await _httpClient.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiContent)!;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto()
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string>() { ex.Message.ToString() },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                return JsonConvert.DeserializeObject<T>(res)!;
            }

        }

    }
}
