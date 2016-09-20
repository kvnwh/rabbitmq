using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMqLibrary;

namespace RabbitMQConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting service...");
            var mq = new RabbitMq();
            var queueName = "kevinQueue";
            mq.Receive(queueName);
            Console.WriteLine("press enter to exit");
            Console.ReadLine();
        }
    }
}