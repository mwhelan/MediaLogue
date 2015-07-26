using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Specs.Library.MediaLogue.WebApi
{
    public static class Requester
    {
        public static HttpRequestMessage Create(string baseAddress, string relativeUrl, HttpMethod httpMethod)
        {
            if (httpMethod == null)
            {
                httpMethod = HttpMethod.Get;
            }

            if (!baseAddress.EndsWith(@"/"))
            {
                baseAddress = baseAddress + @"/";
            }

            var url = string.Format("{0}{1}", baseAddress, relativeUrl);

            return Create(httpMethod, url);
        }

        public static HttpRequestMessage Create(string uri)
        {
            return new HttpRequestMessage(HttpMethod.Get, uri);
        }

        public static HttpRequestMessage Create(HttpMethod httpMethod, string uri)
        {
            return new HttpRequestMessage(httpMethod, uri);
        }

        public static HttpRequestMessage Create(HttpMethod httpMethod, string uri, string mediaType)
        {
            return Create(
                httpMethod,
                uri,
                new MediaTypeWithQualityHeaderValue(mediaType));
        }

        public static HttpRequestMessage Create(HttpMethod httpMethod, string uri, IEnumerable<string> mediaTypes)
        {
            return Create(
                httpMethod,
                uri,
                mediaTypes.ToMediaTypeWithQualityHeaderValues());
        }

        public static HttpRequestMessage Create(HttpMethod httpMethod, string uri, string mediaType, string username, string password)
        {
            return Create(
                httpMethod, uri, new[] { mediaType }, username, password);
        }

        public static HttpRequestMessage Create(HttpMethod httpMethod, string uri, IEnumerable<string> mediaTypes, string username, string password) 
        {
            var request = Create(httpMethod, uri, mediaTypes);
            request.Headers.Authorization = new AuthenticationHeaderValue(
                "Basic",
                EncodeToBase64(
                    string.Format("{0}:{1}", username, password)));

            return request;
        }

        // Private helpers
        private static HttpRequestMessage Create( HttpMethod httpMethod, string uri, MediaTypeWithQualityHeaderValue mediaType)
        {
            return Create(
                httpMethod,
                uri,
                new[] { mediaType });
        }

        private static HttpRequestMessage Create(HttpMethod httpMethod, string uri, IEnumerable<MediaTypeWithQualityHeaderValue> mediaTypes)
        {
            var request = Create(httpMethod, uri);
            request.Headers.Accept.AddTo(mediaTypes);

            return request;
        }

        private static string EncodeToBase64(string value)
        {

            byte[] toEncodeAsBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(toEncodeAsBytes);
        }

        private static IEnumerable<MediaTypeWithQualityHeaderValue> ToMediaTypeWithQualityHeaderValues(this IEnumerable<string> source)
        {
            foreach (var mediaType in source)
            {
                yield return new MediaTypeWithQualityHeaderValue(mediaType);
            }
        }
    }
}
