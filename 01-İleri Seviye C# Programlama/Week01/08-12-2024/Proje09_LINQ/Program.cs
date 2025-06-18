﻿// /*
// LINQ(Language Integrated Query): C# programlama dilinde veri sorgulama ve dönüştürme işlemlerini BASİTLEŞTİREN çok güçlü bir özelliktir. Amaç; farklı veri kaynaklarından sorgulama yapmayı kolaylaştırarak standart ve daha okunabilir hale getirmektir.

// TEMEL ÖZELLİKLER:
// 1- Syntax (Söz dizimi) Bütünlüğü
// 2- Tip Güvenliği
// 3- Görece Performans artışı

// ***NOT: Bazı durumlar için LINQ tercih edilmemek durumunda kalınabilir. İlerledikçe bu durumlara örnek senaryolarla çalışıyor olacağız.

// LINQ Türleri:
// 1) LINQ to Objects
// 2) LINQ to Entities
// 3) LINQ to XML
// 4) LINQ to DataSet

// */


// int[] numbers = [10, 2, 3, 4, 5, 6, 7, 8, 9, 1];
// //Method Syntax
// var result1 = numbers.Where(x => x % 2 == 0);
// var result2 = numbers.OrderByDescending(x => x);
// var result3 = numbers.Select(x => x * x);
// foreach (var number in result2)
// {
//     System.Console.WriteLine(number);
// }

// //Query Syntax
// var result4 =   from number in numbers 
//                 where number%2 == 0
//                 select number;


//LINQ to Objects


List<Student> students = [
    new Student{Id=1, Name="Ayşen",Age=18,Grade=85},
    new Student{Id=2, Name="Mehmet",Age=20,Grade=90},
    new Student{Id=3, Name="Ceren",Age=21,Grade=95},
    new Student{Id=4, Name="Selim",Age=27,Grade=75},
    new Student{Id=5, Name="Gül",Age=19,Grade=95}
];

//Grade değeri 90 ve üzerinde olanları filtreleyelim
//1) Method Syntax
var result = students
                .Where(x => x.Grade >= 90)
                .OrderBy(x => x.Name);
// foreach (var s in result)
// {
//     System.Console.WriteLine($"{s.Name}: {s.Grade}");
// }
//2) Query Syntax
var resultQuery = from student in students
                  where student.Grade >= 90
                  orderby student.Name
                  select student;
// foreach (var s in resultQuery)
// {
//     System.Console.WriteLine($"{s.Name}: {s.Grade}");
// }

//LINQ to Arrays
//ilk yazdığımız LINQ kodları buna net bir örnektir.



class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Grade { get; set; }
}
