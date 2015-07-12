﻿using System;
using System.Net;

namespace MediaLogue.Infrastructure.Data.Tvdb
{
    public class BadResponseException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public BadResponseException(HttpStatusCode statusCode, string message = "Bad response", Exception inner = null)
            : base(message, inner)
        {
            StatusCode = statusCode;
        }
    }
}