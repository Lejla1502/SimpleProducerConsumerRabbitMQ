using RabbitMQ.Client;
using System;
using System.Text;

public class Sender
{
    public static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        using(var connection = factory.CreateConnection()) 
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare("BasicTest", false, false, false, null);

            var message = "Getting started with .NET RabbitMQ";

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish("", "BasicTest", null, body);

            Console.WriteLine("Sent message {0}..", message);
        }

        Console.WriteLine("Pres [Enter] to exit..");
        Console.ReadLine();
    }
}