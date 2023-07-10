using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giphy.API.Models
{
    public class ApiRequest
    {
        public HttpMethod ApiType { get; set; } = HttpMethod.Get;
        public string Url { get; set; }
        public object Data  { get; set; }
    }
}
