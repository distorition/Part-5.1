
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restuarant.Kitchen;

class Program
{
    public static void Main(string[] args)
    {
        CreathostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreathostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<KitchenTableConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });
            services.AddSingleton<Manager>();
            services.AddMassTransitHostedService(true);

        });
}