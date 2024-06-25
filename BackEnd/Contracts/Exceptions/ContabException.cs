using Newtonsoft.Json;
using System.Net;

namespace Contracts.Exceptions
{
    public class ContabApiException : Exception
    {
        public ContabApiException(string msg) : base(msg) { }
        public HttpStatusCode? HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
        public string ContabMessage = Constants.ContabError;

        public string ToJson()
        {
            return JsonConvert.SerializeObject(new
            {
                StatusCode = HttpStatusCode,
                ContabMessage
            });
        }
    }
}
