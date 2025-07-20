using MessageBroker.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace MessageBroker;

public class Producer : IProducer
{
    public async void SendToSamples(string message)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queue: "samples", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(exchange: "samples", routingKey: "samples", body: body);
    }
}