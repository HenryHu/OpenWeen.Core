namespace OpenWeen.Core.Api
{
    public static class Entity
    {
        private static string _accessToken = "";

        public static string AccessToken
        {
            get
            {
                lock (_accessToken)
                    return _accessToken;
            }
            set
            {
                lock (_accessToken)
                    _accessToken = value;
            }
        }


        public static string GetOauthLoginPage(string appid, string appSecret, string redirectUri, string packageName, string scope)
            => $@"{Constants.OAUTH2_ACCESS_AUTHORIZE}?client_id={appid}&response_type=token&redirect_uri={redirectUri}&key_hash={appSecret}{(string.IsNullOrEmpty(packageName) ? "" : $"&packagename={packageName}")}&display=mobile&scope={scope}";
    }
}