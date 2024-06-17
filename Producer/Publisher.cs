using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using RabbitMQ.Client;

class Publisher
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

            while (true)
            {
                var order = new
                {
                    userId = "12345",
                    userName = "John Doe",
                    email = "john.doe@example.com",
                    order = new
                    {
                        orderId = "67890",
                        totalAmount = 150.00,
                        currency = "USD",
                        items = new[]
                        {
                            new { itemId = "1", itemName = "Product 1", quantity = 2, price = 50.00 },
                            new { itemId = "2", itemName = "Product 2", quantity = 1, price = 50.00 }
                        }
                    },
                    payment = new
                    {
                        cardNumber = "4111111111111111",
                        expiryDate = "12/23",
                        cvv = "123"
                    }
                };

                string message = JsonSerializer.Serialize(order);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "orderQueue",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);

                // Espera 5 segundos antes de enviar a próxima mensagem
                Thread.Sleep(5000);
            }
        }
    }
}
