/*
var anahtar kelimesi tür çıkarımı (type inference) sağlayan bir kelimedir.
derleyici değişkenin türünü atanan değerden bakarak otomaitk olarak belirler derleme zamanında bu tür sabit bir şekilde belirlenmiş olur.

-var kullanımı türün açık bir şekilde belli olduğu durumlarda kullanılırsa daha sağlıklı olur.
-tür bir kez belirlendikten sonra değiştirilemez
*/

var number = 5;
var name = "Ali";
string address;
address="İstanbul";

//var price;// yanlış kullanım 

/*
dynamic derleme zamanında tür kontrolü yapmadan çalışma zamanına geçerek orada bu çıkarsamanın yapılmasını sağlar bu yüzden daha esnek bir yapı sunarken , hatalara da daha açık bir yapıdır
*/

// var a=5;
// a="burak";

dynamic a=5;
a="Engin";