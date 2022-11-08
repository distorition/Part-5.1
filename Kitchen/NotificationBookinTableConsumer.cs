
using MassTransit;
using Messagin;

namespace Kitchen
{
    public class NotificationBookinTableConsumer : IConsumer<ITableBook>
    {
        private readonly Consumer consumer;
        public NotificationBookinTableConsumer(Consumer consumer)
        {
            this.consumer = consumer;
        }

        public Task Consume(ConsumeContext<ITableBook> context)
        {
            var result=context.Message.Name;
            return Task.CompletedTask;
        }
    }
}
