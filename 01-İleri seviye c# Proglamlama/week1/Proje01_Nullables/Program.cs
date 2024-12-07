/*
NUllable Types
Bu tipler bir değerin "YOK" (null) olabilmesine izin veren veri türleridir 
genellikle refereans tipler için mümkün olan bir durumda.
Varsayılan olrak null değer içeremeyen value typler istenillirse null değer içerebilcek hale getirilebilirler bunun için type adının yanına (?) yazılır
*/

int? NUllableINt = null;
NUllableINt = 5;

if (NUllableINt.HasValue)
{
    System.Console.WriteLine("Değeri var");
}
else
{
    System.Console.WriteLine("Değeri yok");
}

int? nullableValue = null;
// int? result = nullableValue==null ? 100 : nullableValue;
//Null coalescing operator(??)
int result = nullableValue ?? 100;

//Bir veritabanından kullanıcın yaşını alıyoruz ancak bazı durumlarda bu veri null gelebiliyor.





int GetUserAge(){
    int? age = null;

return age ?? -1;//bu fake bir veri tabanından yaş çekme kodu
}