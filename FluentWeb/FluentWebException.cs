using System;
using System.Net.Http;

namespace FluentWeb
{
    public class FluentWebException : InvalidOperationException
    {
        public HttpResponseMessage HttpResponse { get; }

        public FluentWebException(string message, HttpResponseMessage httpResponse)
            : base(message)
        {
            this.HttpResponse = httpResponse;
        }
    }
}