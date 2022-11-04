using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messagin
{
    public class Consumer:IDisposable
    {
        

        private readonly IConnection connection;
        private readonly IModel _chanel;
        private readonly string _queuName;
        private readonly string _hostname;

        public Consumer(string queuName,string hostName )
        {
            _queuName = queuName;
            _hostname = "shark.rmq.cloudamqp.com";
            var factory = new ConnectionFactory()//подключение к Rabit
            {
                HostName = _hostname,
                Port = 5672,
                UserName = "asdasd",
                Password = "123asd",
                VirtualHost = "asda",
            }; 

             connection = factory.CreateConnection();//создаем подключения
             _chanel = connection.CreateModel();//создаем модель
        }

        public void Recevie(EventHandler<BasicDeliverEventArgs> reciverCallback)
        {
            _chanel.ExchangeDeclare(exchange: "direct_exhange",
                type: "direct");//обьявляем обменник

            _chanel.QueueDeclare(queue:_queuName,
                durable:false,
                exclusive:false,
                autoDelete:false,
                arguments:null);//обьявляем очередь 

            _chanel.QueueBind(queue: _queuName, exchange: "direct_exhange", routingKey: _queuName);//биндим чтобы все работало

            var comsumer= new EventingBasicConsumer(_chanel);//создаем conssumer для канала 
            comsumer.Received += reciverCallback;//обрабатывает прием сообщения 
            _chanel.BasicConsume(queue: _queuName, autoAck: true, consumer: comsumer);//запускаем (autoAck- это отправялет что сообщение получено 

        }

        public void Dispose()
        {
            _chanel?.Dispose();
            connection?.Dispose();
        }
    }
}
