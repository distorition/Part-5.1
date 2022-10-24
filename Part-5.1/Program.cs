using Part_5._1;
using System.Diagnostics;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var rest = new Restaurant();
while (true)
{
    Console.WriteLine("Желаете забронировать столик ?\n1-мы уведомим по смс(асинх)"+"\n2-ожидайте мы вас оповестим(синхронно)");
    if(!int.TryParse(Console.ReadLine(),out var coise)&&coise is not(1 or 2))
    {
        Console.WriteLine("Выберите  1 или 2 ");
        continue;
    }

    var stopWatch = new Stopwatch();
    stopWatch.Start();//замеряем время на броинрование 
    if (coise == 1)
    {
        rest.BookFreeTableAsync(1);
    }
    else
    {
        rest.BookFreeTable(1);
    }
    Console.WriteLine("Спасибо за Ваще обращение");
    stopWatch.Stop();
    var ts=stopWatch.Elapsed;//получаем время потраченное на бронирование 
    Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}");//выводим потраченное время 
}