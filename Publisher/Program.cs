using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(
    massTransitConfigurator =>
    {
        massTransitConfigurator.UsingRabbitMq((context, rabbitConfigurator) =>
        {
            rabbitConfigurator.Host("localhost", "/", h =>
            {
                h.Username("admin");
                h.Password("password");
            });

            //rabbitConfigurator.ReceiveEndpoint(
            //    "new-event-queue",
            //    e =>
            //    {
            //        // e.Consumer(() => new EventConsumer());
            //    });
        });
    }
    );

builder.Services.AddMassTransitHostedService();
builder.Services.AddControllers();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
