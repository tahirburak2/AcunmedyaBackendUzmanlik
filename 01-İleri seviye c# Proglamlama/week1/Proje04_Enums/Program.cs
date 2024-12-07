//sipariş alındı 
using System.ComponentModel;
using System.Reflection;

OrderStatus status = OrderStatus.Received;
// //hazırlanıyor
// status=OrderStatus.proccesing;
// status=OrderStatus.Shipped;

// System.Console.WriteLine(status);
status =OrderStatus.Shipped;
System.Console.WriteLine(status);

string? statusDescription = status
.GetType()?
.GetField(status.ToString())?
.GetCustomAttribute<DescriptionAttribute>()?
.Description;
System.Console.WriteLine(statusDescription);

enum Gender
{
    female,
    male

}



enum OrderStatus
{
    [Description("Sipariş Alındı")]
    Received = 1,

    [Description("Hazırlanıyor")]
    proccesing = 2,

    [Description("Kargoya verildi")]
    Shipped = 3,

    [Description("Teslim edildi")]
    Delivered = 4
}


















//  enum OrderStatus
//  {
//      Received=1,
//      proccesing=2,
//      Shipped=3,
//      Delivered=4
//  }












// enum OrderStatus
// {
//     Received,//0
//     proccesing,//1
//     Shipped,//2
//     Delivered//3
// }

