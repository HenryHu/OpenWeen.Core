using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using OpenWeen.Core.Api;

using static OpenWeen.Core.Api.Entity;
using OpenWeen.Core.Exception;
using System.Diagnostics;

namespace OpenWeen.Core.Helper
{
    internal static class HttpHelper
    {
        private static async Task<string> RequestWith(string uri, Dictionary<string,string> param, HttpMethod method)
        {
            var req = WebRequest.CreateHttp(UrlEncode(uri, param));
            req.Method = method.Method;
            using (var res = await req.GetResponseAsync())
            using (var reader = new StreamReader(res.GetResponseStream()))
                return await reader.ReadToEndAsync();
        }

        private static async Task<string> Request(string uri, Dictionary<string, string> param, HttpMethod method)
        {
            if (AccessToken == null)
                throw new InvalidAccessTokenException("AccessToken is null");
            else
            {
                param.Add("access_token", AccessToken);
                string jsonData = await RequestWith(uri, param, method);

                if (jsonData != null && (jsonData.Contains("{") || jsonData.Contains("[")))
                    return jsonData;
                else
                    throw new InvalidResponseException($"response '{jsonData}' is invalid");
            }
        }

        private static string UrlEncode(string uri, Dictionary<string, string> param)
            => param != null ? $"{uri}?{string.Join("&", param.Select(kvp => $"{kvp.Key}={kvp.Value}"))}" : uri;

        internal static async Task<string> GetStringAsync(string uri, Dictionary<string, string> param)
            => await Request(uri, param, HttpMethod.Get);

        internal static async Task<string> PostAsync<TValue>(string uri, Dictionary<string, TValue> data) where TValue : HttpContent
        {
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                foreach (var item in data)
                    formData.Add(item.Value, item.Key);
                using (var res = await client.PostAsync(uri, formData))
                {
                    return await res.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
