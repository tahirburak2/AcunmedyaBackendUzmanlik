
/*
c#8 ve sonrasında reference türlerini nullable yapısı içinde ele alanilme çzelliği eklenmiştir bu özellik sayesinde kod yazarken null değerlerle çalışmayı daha güvenli hale getirebiliyoruz

Varsayılan Davranış 
Nullable reference types : Kapalı(Tüm reference türlerini varsayılan olarak nullabledir)-> klasik eski yaklaşım

nullable reference types : açık (Tüm reference rürleri varsayılan olarak non-nullabledir)-->Yeni yaklaşım
*/

// string firstName;

// class Category
// {
//     public string? Name {get; set;}
//     #nullable disable
//     public string Title { get; set; }

// }


// string? nullableString = null;
// string nonNullableString = "Merhaba";
// // if(nullableString!=null)
// // System.Console.WriteLine(nullableString.Length);

// System.Console.WriteLine(nullableString?.Length);

// System.Console.WriteLine(nonNullableString.Length);

string? greeting = "Hello!";

// if (greeting==null){
//     greeting="Hello";
// }
greeting ??="hello";
System.Console.WriteLine(greeting);

