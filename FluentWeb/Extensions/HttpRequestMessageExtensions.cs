using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace FluentWeb
{
    public static class HttpRequestMessageExtensions
    {
        public static HttpRequestMessage WithParameter(this HttpRequestMessage message, string name, object value)
        {
            if (value == null)
                return message;
            
            string url = message.RequestUri.ToString();

            if (url.Contains("?"))
                url += "&";
            else
                url += "?";

            url = $"{url}{name}={value}";

            message.RequestUri = new Uri(url, UriKind.Relative);
            
            return message;
        }
        
        public static HttpRequestMessage WithHeader(this HttpRequestMessage message, string name, string value)
        {
            if (!String.IsNullOrEmpty(value))
                message.Headers.Add(name, value);
            
            return message;
        }
        
        public static HttpRequestMessage WithJsonBody(this HttpRequestMessage message, object body, JsonSerializerSettings serializerSettings = null)
        {
            message.Content = new StringContent(JsonConvert.SerializeObject(body, serializerSettings!), Encoding.UTF8, "application/json");
            return message;
        }
    }
}
