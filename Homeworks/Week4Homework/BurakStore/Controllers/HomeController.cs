using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BurakStore.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Text;


namespace BurakStore.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("FakeStoreApi");
    }

    public async Task<IActionResult> Index()
    {
        var responseMessage = await _httpClient.GetAsync("products");
        var contentResponse = await responseMessage.Content.ReadAsStringAsync();
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(contentResponse);
        return View(apiResponse.Products);
    }
    public async Task<IActionResult> Details(int id)
    {
        var responseMessage = await _httpClient.GetAsync($"products/{id}");
        var contentResponse = await responseMessage.Content.ReadAsStringAsync();
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(contentResponse);
        return View(apiResponse.product);
    }

    public async Task<IActionResult> AddProduct()
    {
        var responseMessage = await _httpClient.GetAsync("products/category");
        var contentResponse = await responseMessage.Content.ReadAsStringAsync();
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(contentResponse);
        ViewBag.categorylist = apiResponse.Categories;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        if (ModelState.IsValid)
        {
            var responseMessage = JsonConvert.SerializeObject(product);
            var contentResponse = new StringContent(responseMessage, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("products", contentResponse);

            var newProduct = response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponse>(newProduct.Result);
            return Json(result);


        }
        return View();
    }

    public async Task<IActionResult> AddCategory()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(Category category)
    {
        if (ModelState.IsValid)
        {
            var responseMessage = JsonConvert.SerializeObject(category);
            var contentResponse = new StringContent(responseMessage, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("categories", contentResponse);

            var newProduct = response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ApiResponse>(newProduct.Result);
            return Json(result);


        }
        return View();
    }


     public async Task<IActionResult> Categories()
     {
         var responseMessage = await _httpClient.GetAsync("products/category");
         var contentResponse = await responseMessage.Content.ReadAsStringAsync();
         var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(contentResponse);
         ViewBag.categorylist = apiResponse.Categories;
         return View();
    }
    public async Task<IActionResult> ProductByCategories(string category)
     {
         var responseMessage = await _httpClient.GetAsync($"products/category?type={category}");
         var contentResponse = await responseMessage.Content.ReadAsStringAsync();
        var apiResponse=JsonConvert.DeserializeObject<ApiResponse>(contentResponse);
         return View(apiResponse.Products.ToList());
     }


}
