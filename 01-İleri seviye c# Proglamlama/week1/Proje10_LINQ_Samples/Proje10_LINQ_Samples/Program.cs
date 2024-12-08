using LINQ_Samples;
using Proje10_LINQ_Samples;


Repository repository =new Repository();

#region Tüm kategorileri listeleme

    //var result = repository.Categories.ToList();
    // var result = from category in repository.Categories
    //             select category;
#endregion

#region Tüm Kategorilerin adını listeleme
    // var categoryNames=repository
    //     .Categories
    //     .Select(x=>x.Name)
    //     .ToList();
    // var categoryNames = from category in repository.Categories
    //                     select category.Name;
#endregion

#region Sadece silinmemiş kategorileri Lsitemeleme
    // var deletedcategories = repository.Categories
    //     .Where(x=>x.IsDeleted==false)
    //     .ToList();
#endregion

#region  Ürünleirn Fiyatlarını Listeme
    // var result = repository.Products.Where(x=> x.Price>1000).ToList();
#endregion

#region Kategoriye göre gruplanmış ürünleri listeleme
    // var groupedByCategory= repository.Products
    // .GroupBy(x=>x.CategoryId);
    // var groupedByCategory = from product in repository.Products
    //                         group product by product.CategoryId;
#endregion

#region Tedarikçi Başına ürün sayısı
    var productCountsBySupplier= repository.Products
    .GroupBy(p=>p.SupplierId)
    .Select(g=> new { SupplierId = g.Key,ProductCount=g.Count()})
    .ToList();
#endregion
