using System.Net.Http;

namespace FluentWeb
{
    public static class StringExtensions
    {
        public static HttpRequestMessage Get(this string endpoint) => new HttpRequestMessage(HttpMethod.Get, endpoint);
        
        public static HttpRequestMessage Post(this string endpoint) => new HttpRequestMessage(HttpMethod.Post, endpoint);
        
        public static HttpRequestMessage Put(this string endpoint) => new HttpRequestMessage(HttpMethod.Put, endpoint);
        
        public static HttpRequestMessage Patch(this string endpoint) => new HttpRequestMessage(new HttpMethod("PATCH"), endpoint);
        
        public static HttpRequestMessage Delete(this string endpoint) => new HttpRequestMessage(HttpMethod.Delete, endpoint);
        
        public static HttpRequestMessage Head(this string endpoint) => new HttpRequestMessage(HttpMethod.Head, endpoint);
        
        public static HttpRequestMessage Options(this string endpoint) => new HttpRequestMessage(HttpMethod.Options, endpoint);
        
        public static HttpRequestMessage Trace(this string endpoint) => new HttpRequestMessage(HttpMethod.Trace, endpoint);
    }
}