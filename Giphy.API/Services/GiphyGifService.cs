using Giphy.API.Models;
using Giphy.API.Services.IServices;
using Giphy.Core.Entities;

namespace Giphy.API.Services
{
    public class GiphyGifService : IGiphyGifService
    {
        private readonly IWebApiCaller _webApiCaller;

        public GiphyGifService(IWebApiCaller webApiCaller)
        {
            _webApiCaller = webApiCaller;
        }

        public Task<T> SearchAsync<T>(GiphyGifRequestParametrs param)
        {
           return _webApiCaller.SendAsync<T>(CrateRequest(HttpMethod.Get,param));
        }

        private static ApiRequest CrateRequest(HttpMethod method, GiphyGifRequestParametrs param)
        {
            return CrateRequest<object>(method, null, param);
        }
        private static ApiRequest CrateRequest<T>(HttpMethod method, T? data, GiphyGifRequestParametrs param)
        {
            return new ApiRequest()
            {
                ApiType = method,
                Data = data,
                Url = SD.GiphyApiBase +
                  $"search?api_key={param.api_key}&q={param.q}&limit={param.limit}&offset={param.offset}&rating={param.rating}&lang={param.lang}&bundle={param.bundle}"

                //Url = "https://api.giphy.com/v1/gifs/search?api_key=swFGRRM9sVt8H7cvFDN0biXSDv1gzVpx&q=1&limit=25&offset=0&rating=g&lang=en&bundle=messaging_non_clips"
            };
            //Need to create function with string builder receve Url
        }
    }
}
