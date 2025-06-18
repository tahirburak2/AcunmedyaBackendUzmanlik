﻿abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public abstract decimal CalculateDiscount();
}

class Electronic : Product
{
    public int Period { get; set; }

    public override decimal CalculateDiscount()
    {
        throw new NotImplementedException();
    }
}

class Food : Product
{
    public DateTime ExpirationDate { get; set; }

    public override decimal CalculateDiscount()
    {
        throw new NotImplementedException();
    }
}

interface IProductRepository{
    Product GetProductById(int id);
    List<Product> GetAll();
}

class ProductRepository : IProductRepository
{
    public List<Product> GetAll()
    {
        throw new NotImplementedException();
    }

    public Product GetProductById(int id)
    {
        return new Electronic { Id = id, Name = "IPhone", Period = 5 };
    }
}

class OrderService
{
    private readonly IProductRepository _productRepository;

    public OrderService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void ProcessOrder(int id){
        var product = _productRepository.GetProductById(id);
        //burada order ile ilgili işlemler yapılıyor...
    }
    
}