using System;
using EShop.MVC.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EShop.MVC.Helpers
{
    public static class UrlHelpers
    {
        // http://localhost:5210/images/products/elektronik.png
        public static string ApiContent(this IUrlHelper urlHelper, string? path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }
            var baseUrl = urlHelper.ActionContext.HttpContext.GetApiBaseUrl().TrimEnd('/');
            baseUrl = baseUrl.EndsWith("/api") ? baseUrl[..^4] : baseUrl;
            Console.WriteLine($"BASE URL: {baseUrl}");
            Console.WriteLine($"RESİM URL BİLGİSİ: {baseUrl}{path}");
            return $"{baseUrl}{path}";
        }
    }
}
