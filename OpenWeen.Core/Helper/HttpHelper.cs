using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using OpenWeen.Core.Exception;
using static OpenWeen.Core.Api.Entity;

namespace OpenWeen.Core.Helper
{
    internal static class HttpHelper
    {
        private static async Task<string> RequestWith(string uri, Dictionary<string, string> param, HttpMethod method)
        {
            var req = WebRequest.CreateHttp(UrlEncode(uri, param));
            req.Method = method.Method;
            using (var res = await req.GetResponseAsync())
            using (var reader = new StreamReader(res.GetResponseStream()))
                return await reader.ReadToEndAsync();
        }

        private static async Task<string> Request(string uri, Dictionary<string, string> param, HttpMethod method)
        {
            var token = "";
            lock (AccessToken)
            {
                if (AccessToken == null)
                    throw new InvalidAccessTokenException("AccessToken is null");
                token = AccessToken;
            }

            if (param == null)
                param = new Dictionary<string, string>();
            param.Add("access_token", token);
            string jsonData = await RequestWith(uri, param, method);

            if (jsonData != null && (jsonData.Contains("{") || jsonData.Contains("[")))
                return jsonData;
            else
                throw new InvalidResponseException($"response '{jsonData}' is invalid");
        }

        private static string UrlEncode(string uri, Dictionary<string, string> param)
            => param != null ? $"{uri}?{string.Join("&", param.Select(kvp => $"{kvp.Key}={kvp.Value}"))}" : uri;

        internal static async Task<string> GetStringAsync(string uri, Dictionary<string, string> param)
            => await Request(uri, param, HttpMethod.Get);

        internal static async Task<string> PostAsync<TValue>(string uri, Dictionary<string, TValue> data) where TValue : HttpContent
        {
            var token = "";
            lock (AccessToken)
            {
                if (AccessToken == null)
                    throw new InvalidAccessTokenException("AccessToken is null");
                token = AccessToken;
            }
            using (var client = new HttpClient())
            {
                if (data.Values.Count(item => item.GetType() == typeof(StreamContent)) > 0)
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        foreach (var item in data)
                        {
                            if (item.Value.GetType() == typeof(StreamContent))
                            {
                                formData.Add(item.Value, item.Key, "pic.png");
                            }
                            else
                            {
                                formData.Add(item.Value, item.Key);
                            }
                        }
                        formData.Add(new StringContent(token), "access_token");
                        using (var res = await client.PostAsync(uri, formData))
                        {
                            return await res.Content.ReadAsStringAsync();
                        }
                    }
                }
                else
                {
                    var items = new Dictionary<string, string>();
                    foreach (var item in data)
                    {
                        items.Add(item.Key, await item.Value.ReadAsStringAsync());
                    }
                    items.Add("access_token", token);
                    using (var formData = new FormUrlEncodedContent(items))
                    {
                        using (var res = await client.PostAsync(uri, formData))
                        {
                            return await res.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
        }
    }
}