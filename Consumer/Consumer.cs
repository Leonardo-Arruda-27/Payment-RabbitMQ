using Consumer.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Consumer
{
    class Consumer
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "orderQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var order = JsonSerializer.Deserialize<Order>(message);

                    Console.WriteLine(" [x] Received Order for User: {0}, Total Amount: {1}", order.userName, order.order.totalAmount);

                    // Process the payment
                    ProcessPayment(order.payment);

                    // Other processing like updating inventory, sending notifications, etc.
                };
                channel.BasicConsume(queue: "orderQueue",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        public static void ProcessPayment(Payment payment)
        {
            // Simulate payment processing
            Console.WriteLine(" Processing payment for card number: {0}", payment.cardNumber);
            // Here you would call the bank API to process the payment
        }
    }
}
