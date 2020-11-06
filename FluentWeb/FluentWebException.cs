using System;
using System.Net.Http;

namespace FluentWeb
{
    public class FluentWebException : Exception
    {
        public HttpResponseMessage HttpResponse { get; }
        
        public FluentWebException(HttpResponseMessage httpResponse)
        {
            this.HttpResponse = httpResponse;
        }
    }
}