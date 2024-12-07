//Eticaret sistemimiz olsun. ürünleirm farklı tipleri olabilir Elektronik, giyim , gıda gibi temel ürünlerin bazı özellikleri aynı iken bazıları farklı iken üst sınıf olarak planlayacağımız product bir abstract class olacaktır


// abstract class Product
// {
//     public int Id { get; set; }
//     public string? Name { get; set; }
//     public decimal Price { get; set; }
//     public abstract decimal CalculatedDiscountedPrice();

// }

// class Electronic : Product
// {
//     public int warrantyPeriod { get; set; }
//     public override decimal CalculatedDiscountedPrice()
//     {
//         throw new NotImplementedException();
//     }
// }

// class Clothing:Product{
//     public string? Size { get; set; }
//     public override decimal CalculatedDiscountedPrice()
//     {
//         throw new NotImplementedException();
//     }
// }
Electronic electronic1 =new(){
    
    Name ="müzik çalar",
    Id = 1,
    Price =580
};



interface IProduct
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public decimal CalculatedDiscountedPrice(){
        double result = (double)Price*0.1;
        return Convert.ToDecimal(result);
    }
}
class Electronic : IProduct
{
    public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
 

    public decimal CalculatedDiscountedPrice()
    {
        throw new NotImplementedException();
    }
}

class Clothing : IProduct
{
    public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string? Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public decimal Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
