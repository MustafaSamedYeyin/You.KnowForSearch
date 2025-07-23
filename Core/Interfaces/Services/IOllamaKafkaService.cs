namespace OllamaKafka;

public interface IOllamaKafkaService
{
    public Task<bool> ConsumeMessageAsync(string topic);
    public Task<bool> ProduceMessageAsync(string topic, string message);

}