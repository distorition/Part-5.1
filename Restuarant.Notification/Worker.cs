using Messagin;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restuarant.Notification
{
    public class Worker : BackgroundService
    {
        private readonly Consumer consumer;
        public Worker()
        {
            consumer = new Consumer("BokkingNotification", "localHost");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            consumer.Recevie((sender, args) => //когда пришло сообщение
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);//декодируем (расшифровываеем то что зашифровали)
                Console.WriteLine("[x] Recivered {0}", message);
            });
        }
    }
}
