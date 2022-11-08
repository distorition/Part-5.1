using Kitchen;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<NotificationBookinTableConsumer>();

    x.UsingRabbitMq((contex, cfg) =>
    {
        cfg.ConfigureEndpoints(contex);
    });
});

builder.Services.AddMassTransitHostedService();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.Run();

