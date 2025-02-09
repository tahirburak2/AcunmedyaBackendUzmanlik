using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace EShop.Shared.Dtos.ResponseDtos;

//Bu sınıf içinde
//1) Geri döndürülecek detayı
//2) Geri Döndürülecek hata mesajını
//3) Geri Döndürülecek hata kodunu
//4) Geri Döndürülecek başarılı olup olmadığını tutacağız
public class ResponseDto<T>
{
    public T? Data { get; set; }
    public string? Error { get; set; }
    [JsonIgnore]
    public int StatusCode { get; set; }
    public bool IsSuccessful { get; set; }


    //Başarılı Durumlarda kullanılacak constructor metotlar

    public static ResponseDto<T> Success(T? data, int statusCode)
    {
        return new ResponseDto<T>
        {
            Data = data,
            StatusCode = statusCode,
            IsSuccessful = true
        };

    }

    //Başarılı ama geriye data döndürülmeyecek durumlarda kullanulacak metot

    public static ResponseDto<T> Success(int statusCode)
    {
        return new ResponseDto<T>
        {
            Data = default,
            StatusCode = statusCode,
            IsSuccessful = true
        };
    }

    //Hata durumlarında kullanılacak metot
    public static ResponseDto<T> Fail(string error, int statusCode)
    {
        return new ResponseDto<T>
        {
            Error = error,
            StatusCode = statusCode,
            IsSuccessful = false
        };
    }
}
