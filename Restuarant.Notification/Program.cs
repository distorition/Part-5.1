using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restuarant.Notification;

class Program
{
    public static void Main(string[] arsg)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CreateeHostBuilder(arsg).Build().Run();
    }


    public static IHostBuilder CreateeHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContexxt, services) =>
        {
            services.AddHostedService<Worker>();
        });
} 