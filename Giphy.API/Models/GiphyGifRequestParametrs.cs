using System.Security.Principal;

namespace Giphy.API.Models
{
    public class GiphyGifRequestParametrs
    {
        //
        public string api_key { get; set; }
        public string q { get; set; }
        public int? limit { get; set; }
        public int? offset { get; set; }
        public string? rating { get; set; }
        public string?  lang { get; set; }
        public string? random_id { get; set; }
        public string? bundle { get; set; }
    }
}
