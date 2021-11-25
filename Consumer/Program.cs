using Consumer;
using MassTransit;

Microsoft.Extensions.Hosting.IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(
            massTransitConfigurator =>
            {
                massTransitConfigurator.UsingRabbitMq((context, rabbitConfigurator) =>
                {
                    rabbitConfigurator.Host("localhost", "/", h =>
                    {
                        h.Username("admin");
                        h.Password("password");
                    });

                    rabbitConfigurator.ReceiveEndpoint(
                        "consoleConsumer-Queue2",
                        e=>
                        {
                            e.Consumer(() => new EventConsumer());
                        }
                        );
                });
            }
            );
                services.AddMassTransitHostedService(true);
        services.AddHostedService<Worker>();


    })
    .Build();

await host.RunAsync();
