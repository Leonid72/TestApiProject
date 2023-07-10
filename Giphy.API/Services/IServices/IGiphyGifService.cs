using Giphy.API.Models;
using Giphy.Core.Entities;

namespace Giphy.API.Services.IServices
{
    public interface IGiphyGifService
    {
        Task<T> SearchAsync<T>(GiphyGifRequestParametrs param);
    }
}
