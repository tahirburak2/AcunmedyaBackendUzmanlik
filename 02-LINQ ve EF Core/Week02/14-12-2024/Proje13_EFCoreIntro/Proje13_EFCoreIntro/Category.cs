using System;

namespace Proje13_EFCoreIntro;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CratedDate { get; set; }
    public bool IsActive { get; set; }
}
