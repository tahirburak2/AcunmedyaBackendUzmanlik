//           SENKRON
// //string içinde \r ne işe yarar araştırınız

// System.Console.WriteLine("1. işlem:(5 saniye)");
// for (int i = 1; i <= 5; i++)
// {
//     System.Console.WriteLine($"\r[1. işlem] geçen süre: {i} saniye");
//     Thread.Sleep(1000);
// }
// System.Console.WriteLine("1. işlem için verilen '5' saniye sora ermiştir.");

// //string içinde \r ne işe yarar araştırınız

// System.Console.WriteLine("2. işlem:(10 saniye)");
// for (int i = 1; i <= 10; i++)
// {
//     System.Console.WriteLine($"\r[2. işlem] geçen süre: {i} saniye");
//     Thread.Sleep(1000);
// }
// System.Console.WriteLine("2. işlem için verilen '10' saniye sora ermiştir.");



//          ASENKRON
string task1Status = "5 saniyelik işlem bekleniyor...";
string task2Status = "10 saniyelik işlem bekleniyor...";

object consoleLock = new Object();

Thread thread1 = new Thread(() =>
{
    for (int i = 1; i <= 5; i++)
    {
        lock (consoleLock)
        {
            task1Status = $"5 saniyelik işlem için geçen süre: {i} saniye";
            Console.Clear();
            System.Console.WriteLine($"{task1Status}\n{task2Status}");
        }
        Thread.Sleep(1000);
    }
    lock (consoleLock)
    {
        task1Status = "5 saniyelik işlem tamamlandı!";
        Console.Clear();
        System.Console.WriteLine($"{task1Status}\n{task2Status}");
    }
});

Thread thread2 = new Thread(() =>
{
    for (int i = 1; i <= 10; i++)
    {
        lock (consoleLock)
        {
            task2Status = $"10 saniyelik işlem için geçen süre: {i} saniye";
            Console.Clear();
            System.Console.WriteLine($"{task1Status}\n{task2Status}");
        }
        Thread.Sleep(1000);
    }
    lock (consoleLock)
    {
        task2Status = "10 saniyelik işlem tamamlandı!";
        Console.Clear();
        System.Console.WriteLine($"{task1Status}\n{task2Status}");
    }
});

thread1.Start();
thread2.Start();