using Newtonsoft.Json;
using System;
using System.Text;

namespace publicApi.Services.Helpers
{
    public static class Encoding_helper
    {
        public static string EncodeToBase64<T>(T value)
        {
            var valueJson = JsonConvert.SerializeObject(value);
            var jsonBytes = Encoding.UTF8.GetBytes(valueJson);
            return Convert.ToBase64String(jsonBytes);
        }

        public static T DecodeFromBase64<T>(string value, bool hasUriEnconding = true)
        {
            if (hasUriEnconding)
            {
                value = value.Replace('-', '+').Replace('_', '/').PadRight(4 * ((value.Length + 3) / 4), '=');
            }

            var valueBytes = Convert.FromBase64String(value);
            var valueStr = Encoding.UTF8.GetString(valueBytes);

            return JsonConvert.DeserializeObject<T>(valueStr);
        }
    }
}
