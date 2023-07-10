using Giphy.API.Models;
using Giphy.API.Services.IServices;
using Giphy.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Giphy.API.Controllers
{
    public class GiphyGifController : BaseApiController
    {
        private readonly IGiphyGifService _giphyGif;
        protected ResponseDto _response;
        public GiphyGifController(IGiphyGifService giphyGif)
        {
            _giphyGif = giphyGif;
            _response = new ResponseDto();
        }

        [HttpGet]
        [Route("Search")]
        public async Task<ActionResult<ResponseDto>> Search([FromQuery] GiphyGifRequestParametrs param)
        {
            try
            {
                 var result = await _giphyGif.SearchAsync<Application>(param);
                _response.Result = result.data.Select(a => a.url).ToList();;
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


