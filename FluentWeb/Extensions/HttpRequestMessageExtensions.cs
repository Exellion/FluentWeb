using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        public static async Task<TResult> FetchAs<TResult>(this HttpRequestMessage message, HttpClient httpClient, CancellationToken cancellation, JsonSerializerSettings serializerSettings = null)
        {
            var response = await httpClient.SendAsync(message, cancellation);

            if (!response.IsSuccessStatusCode)
                throw new WebException($"{response.StatusCode}. {response.ReasonPhrase}");

            string json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(json, serializerSettings);
        }
    }
}
