/*
LINQ(Language Integrated Query): C# proglamlama dilinde veri sorgulama ve dönüştürme işlemlerini basitleştiren çok güçlü bir özelliktir Amaç: Fakrlı veri kaynaklarındaı sorgulama yapmayı kolaylaştırark standart ve daha okunabilir hale getirmektir.

TEMEL ÖZELLİKLER:
1-Syntax (söz dizimi) bütünlüğü
2-Tip güvenliği
3-Görece Performans artışı


***NOT: Bazı durumlar için LINQ tercih edilmemk durumunda kalınabilir. İlerledikçe bu durumlara örnek seneryolarla çalışıypr olacağıkz.

LINQ Türleri:
1) LINQ to Object
2) LINQ to Entities
3)  LINQ to XML
4) LINQ to DataSet
*/


//Method Syntax

// int[] numbers = [10, 2, 3, 4, 5, 6, 7, 8, 9, 1];

// var result1 = numbers.Where(x => x % 2 == 0);

// var result2 = numbers.OrderBy(x => x);

// var result3 = numbers.Select(x => x * x);

// foreach (var number in result2)
// {
//     System.Console.WriteLine(number);
// }

// //query syntax
// var result4 = from number in numbers
//               where number % 2 == 0
//               select number;

//LINQ to Objects

List<Student> students = [
    new Student{Id=1,Name="Ayşen",Age=18,Grade=85},
    new Student{Id=2,Name="atakan",Age=19,Grade=95},
    new Student{Id=3,Name="burak",Age=19,Grade=100},
    new Student{Id=4,Name="samet",Age=25,Grade=75},
    new Student{Id=5,Name="burhan",Age=32,Grade=55}
];

//Grade değeri 90dan ve üzeri olanları filtrelemek istiyoruz

//1)Method Syntax
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
//ilk yaptığımız LINQ kodları buna ner bir örnektir







class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Grade { get; set; }
}