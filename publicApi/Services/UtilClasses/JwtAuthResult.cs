using System;

namespace publicApi.Service.UtilClasses
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }

        public DateTime AccessTokenExpiration { get; set; }
    }
}