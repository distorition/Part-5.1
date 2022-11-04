using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messagin
{
    public class Producer
    {
        private readonly string _queuName;
        private readonly string _hostname;

        public Producer(string queuName,string hostname)
        {
            _queuName = queuName;
            _hostname = "shark.rmq.cloudamqp.com";
        }

        public void Send(string message)
        {
            var factory = new ConnectionFactory()//подключение к Rabit
            {
                HostName = _hostname,
                Port = 5672,
                UserName = "asdasd",
                Password = "123asd",
                VirtualHost = "asda",
            };

            using var connection=factory.CreateConnection();//создаем подключения
            using var channel=connection.CreateModel();//создаем модель

            channel.ExchangeDeclare("direct_exhange" //имя нашего обмена (Enxchange)
                , "direct" //тип точки
                , false// будет ли сообщения находиться в очереди если никого из потребителей нет
                , false,//автоудаления сообщения 
                null);

            var body =Encoding.UTF8.GetBytes(message);//преобразовываем сообщение в байты ( нужно для отправки)
            channel.BasicPublish(exchange: "direct_exhange", //так указываем в какой именно (Exchange) будем отправлять сообщение 
                routingKey: _queuName, //определям в какую очередь будет отправлен 
                basicProperties: null,
                body: body); //то где содержиться наше сообщение ( то что будем отправлять )
                
        }

     
    }
}
