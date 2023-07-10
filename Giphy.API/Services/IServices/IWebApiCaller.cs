using Giphy.API.Models;

namespace Giphy.API.Services.IServices
{
    public interface IWebApiCaller
    {
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
