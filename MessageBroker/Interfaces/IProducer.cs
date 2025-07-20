namespace MessageBroker.Interfaces;

public interface IProducer
{
    void SendToSamples(string message);
}
