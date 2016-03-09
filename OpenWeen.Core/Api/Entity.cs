using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeen.Core.Api
{
    public static class Entity
    {
        public static string AccessToken { get; set; }
        public static string GetOauthLoginPage(string appid, string appSecret, string redirectUri, string packageName, string scope)
            => $@"{Constants.OAUTH2_ACCESS_AUTHORIZE}?client_id={appid}&response_type=token&redirect_uri={redirectUri}&key_hash={appSecret}{(string.IsNullOrEmpty(packageName) ? "" : $"&packagename={packageName}")}&display=mobile&scope={scope}";

    }
}
