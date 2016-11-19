using System;
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

        private static string UrlEncode(string uri, Dictionary<string, string> param)
            => param != null ? $"{uri}?{string.Join("&", param.Select(kvp => $"{kvp.Key}={kvp.Value}"))}" : uri;

        internal static async Task<string> GetStringAsync(string uri, Dictionary<string, string> param)
        {
            if (string.IsNullOrEmpty(AccessToken))
                throw new InvalidAccessTokenException("AccessToken is null");
            return await GetStringAsync(uri, AccessToken, param);
        }

        internal static async Task<string> GetStringAsync(string uri,string token,Dictionary<string,string> param)
        {
            if (param == null)
                param = new Dictionary<string, string>();
            param.Add("access_token", token);
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(30);
                using (var res = await client.GetAsync(UrlEncode(uri, param)))
                {
                    return await res.Content.ReadAsStringAsync();
                }
            }
        }
        internal static async Task<string> PostAsync<TValue>(string uri, Dictionary<string, TValue> data) where TValue : HttpContent
        {
            if (string.IsNullOrEmpty(AccessToken))
                throw new InvalidAccessTokenException("AccessToken is null");
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
                        formData.Add(new StringContent(AccessToken), "access_token");
                        using (var res = await client.PostAsync(uri, formData))
                        {
                            return await res.Content.ReadAsStringAsync();
                        }
                    }
                }
                else
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    var items = new Dictionary<string, string>();
                    foreach (var item in data)
                    {
                        items.Add(item.Key, await item.Value.ReadAsStringAsync());
                    }
                    items.Add("access_token", AccessToken);
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