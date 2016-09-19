using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQIntro
{
    class Program
    {
        private const string hostName = "localhost";
        private const string userName = "guest";
        private const string password = "guest";

        static void Main(string[] args)
        {
            var factory = new RabbitMQ.Client.ConnectionFactory()
            {
                Password = password,
                UserName = userName,
                HostName = hostName
            };
            var connection = factory.CreateConnection();
            var model = connection.CreateModel();

            #region create exchange/queue/binding

            var queueName = "myqueuefromvs";
            //model.QueueDeclare(queueName, true, false, false, null);
            //Console.WriteLine("queue created");

            //var exchangeName = "myexchangefromvs";
            var exchangeName = "";
            //model.ExchangeDeclare(exchangeName, ExchangeType.Topic);
            //Console.WriteLine("exchange created");

            //var routingKey = "cars";
            //model.QueueBind(queueName, exchangeName, routingKey);
            //Console.WriteLine("exchage and queue bound");

            #endregion

            #region sending 

            var properties = model.CreateBasicProperties();
            properties.Persistent = false;

            byte[] messageBuffer = Encoding.Default.GetBytes("this is my message from vs again");
            model.BasicPublish(exchangeName, queueName, properties, messageBuffer);
            Console.WriteLine("Message sent");

            #endregion

            Console.ReadLine();
        }
    }
}