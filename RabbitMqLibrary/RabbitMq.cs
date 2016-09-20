using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace RabbitMqLibrary
{
    public class RabbitMq
    {
        private ConnectionFactory _factory;

        public RabbitMq(string host = "localhost", string user = "guest", string password = "guest")
        {
            _factory = new ConnectionFactory
            {
                HostName = host,
                UserName = user,
                Password = password
            };
        }

        public void Send(string message)
        {
            Send("kevinQueue", message);
        }


        public void Send(string queueName, string msg)
        {
            if (_factory == null) throw new NullReferenceException("Factory is null");
            using (var conn = _factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(msg);
                channel.BasicPublish(exchange: "",
                    routingKey: queueName,
                    basicProperties: null,
                    body: body);
            }
        }

        public void Receive(string queueName)
        {
            if (_factory == null) throw new NullReferenceException("Factory is null");
            Console.WriteLine("testing if it writes out the file");
            using (var conn = _factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ev) =>
                {
                    Console.WriteLine("received a message");
                    var body = ev.Body;
                    var message = Encoding.UTF8.GetString(body);
                    System.IO.File.WriteAllText(@"C:\temp\answer.txt", message);
                };

                channel.BasicConsume(queue: queueName, noAck: true, consumer: consumer);
            }
        }
    }
}