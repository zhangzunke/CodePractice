using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQSend
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
                    //NewMethod(args, channel);
                    var queueName = channel.QueueDeclare().QueueName;
                    //fanout model
                    channel.ExchangeDeclare(exchange: "fanoutEC", type: "fanout");
                    Console.WriteLine("Please enter your message:");
                    while (true)
                    {
                        var message = Console.ReadLine();
                        if (!string.IsNullOrEmpty(message) && message.ToUpper() == "Q")
                        {
                            break;
                        }
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish(exchange: "fanoutEC", routingKey: "", basicProperties: null, body: body);
                    }
                }
            }
        }

        /// <summary>
        /// This is a queue send
        /// </summary>
        /// <param name="args"></param>
        /// <param name="channel"></param>
        private static void NewMethod(string[] args, IModel channel)
        {
            channel.QueueDeclare(queue: "hello", durable: true, exclusive: false, autoDelete: false, arguments: null);
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            for (int i = 0; i < 5; i++)
            {
                string message = args.Length > 0 ? args[0] : $"{i + 1} Hello RabbitMQ!";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: properties, body: body);
                Console.WriteLine($"A send a {message} message");
            }
        }
    }
}
