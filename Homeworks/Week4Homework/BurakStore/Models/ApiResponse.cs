using System;
using System.ComponentModel;

namespace BurakStore.Models;

public class ApiResponse
{
    public string Status { get; set; }
    public string Message { get; set; }=string.Empty;
    public List<Product> Products { get; set; }
    public Product product { get; set; }
    public List<string> Categories { get; set; }
    public Category category { get; set; }
}
