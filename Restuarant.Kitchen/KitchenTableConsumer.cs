using MassTransit;
using Messagin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Kitchen
{
    internal class KitchenTableConsumer : IConsumer<ITableBlocked>
    {
        private readonly Manager manager;

        public KitchenTableConsumer(Manager manager)
        {
            this.manager = manager;
        }

        public Task Consume(ConsumeContext<ITableBlocked> context)
        {
            var result = context.Message.Succes;
            if (result)
            {
                manager.CheckKitchenRedy(context.Message.orderId, context.Message.Preorder);
            }
            return context.ConsumeCompleted;
        }
    }
}
