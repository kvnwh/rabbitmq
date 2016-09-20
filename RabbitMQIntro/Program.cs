using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMqLibrary;

namespace RabbitMQIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var mq = new RabbitMq();

            mq.Send("kevin sending from vs");

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

            //var properties = model.CreateBasicProperties();
            //properties.Persistent = false
            Console.WriteLine("Message sent");

            #endregion

            Console.ReadLine();
        }
    }
}