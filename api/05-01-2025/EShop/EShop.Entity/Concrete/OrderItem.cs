using System;
using EShop.Entity.Abstract;

namespace EShop.Entity.Concrete;

public class OrderItem:BaseEntity
{
    private OrderItem()
    {
        
    }
    public OrderItem(int orderId, int productId, decimal unitePrice, int quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        UnitePrice = unitePrice;
        Quantity = quantity;
    }

    public int OrderId { get; set; }
    public Order? Order { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public decimal UnitePrice { get; set; }
    public int Quantity { get; set; }
    
}
