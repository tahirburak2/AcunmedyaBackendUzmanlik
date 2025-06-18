using System;
using System.Text.Json.Serialization;

namespace EShop.MVC.Models
{
    public class TokenModel
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; } = string.Empty;

        [JsonPropertyName("accessTokenExpirationDate")]
        public DateTime AccessTokenExpirationDate { get; set; }

    }
}
