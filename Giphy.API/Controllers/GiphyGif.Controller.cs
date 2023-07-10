using Giphy.API.Models;
using Giphy.API.Services.IServices;
using Giphy.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Giphy.API.Controllers
{
    public class GiphyGifController : BaseApiController
    {
        private readonly IGiphyGifService _giphyGif;
        private IMemoryCache _cache;
        private const string giphyGifListCacheKey = "giphyGifList";
        protected ResponseDto _response;


        public GiphyGifController(IGiphyGifService giphyGif, IMemoryCache cache)
        {
            _giphyGif = giphyGif;
            _response = new ResponseDto();
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<ResponseDto>> Search([FromQuery] GiphyGifRequestParametrs param)
        {
            try
            {
                if (_cache.TryGetValue(giphyGifListCacheKey, out List<string> giphyGiflist))
                {
                    _response.Result = giphyGiflist;
                }
                else
                { 
                    var result = await _giphyGif.SearchAsync<Application>(param);
                    
                    //Need to emplemet to extention class
                    _response.Result = result.data.Select(a => a.url).ToList();
                     giphyGiflist =  result.data.Select(a => a.url).ToList();
                     var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal)
                    .SetSize(1024);
                    _cache.Set(giphyGifListCacheKey, _response.Result, cacheEntryOptions);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.Message.ToString() };
            }
            return Ok(_response);
        }
    }
}


