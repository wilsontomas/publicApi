namespace publicApi.Service.ConfigurationOptions
{
    public class JsonWebTokenOptions
    {
        public const string Section = "JsonWebToken";

        public string Audience { get; set; }

        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; }

        public int RefreshTokenExpiration { get; set; }

        public double ClockSkew { get; set; }

        public string Secret { get; set; }
    }
}
