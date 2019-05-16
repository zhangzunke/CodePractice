using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace RabbitMQReceive
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "10.110.120.147",
                UserName = "admin",
                Password = "123456"
            };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //NewMethod(channel);
                    channel.ExchangeDeclare(exchange: "fanoutEC", type: "fanout");
                    var queuename = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queue: queuename, exchange: "fanoutEC", routingKey: "");
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var message = Encoding.UTF8.GetString(ea.Body);
                        Console.WriteLine($"B Received {message} message");
                        Thread.Sleep(6000);
                        Console.WriteLine("B Done");
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    };
                    channel.BasicConsume(queue: queuename, autoAck: false, consumer: consumer); ;
                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }

        private static void NewMethod(IModel channel)
        {
            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body);
                Console.WriteLine($"B Received {message} message");
                Thread.Sleep(6000);
                Console.WriteLine("B Done");
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };
            channel.BasicConsume(queue: "hello", autoAck: false, consumer: consumer);
        }
    }
}
