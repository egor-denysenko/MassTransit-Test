using MassTransit;
using SharedEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    internal class EventConsumer : IConsumer<ConsoleMessage>
    { 
        public Task Consume(ConsumeContext<ConsoleMessage> context)
        {
            //throw new NotImplementedException();
            Console.WriteLine($"{context.Message.Numerone} - {context.Message.Stringa}");

            return Task.CompletedTask;
        }
    }
}
