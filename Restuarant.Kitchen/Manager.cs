using MassTransit;
using Messagin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Kitchen
{
    internal class Manager
    {
        private readonly IBus bus;

        public Manager(IBus bus)
        {
            this.bus = bus;
        }

        public void CheckKitchenRedy(Guid oredrId,Dish? dish)
        {
            bus.Publish<IKitchenRedy>(new KichenRedy(oredrId, true));
        }
    }
}
