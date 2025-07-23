using Confluent.Kafka;
using Core.Interfaces;

namespace Business.Services;

public class KafkaService : IKafkaService
{
    public async Task<string> ConsumeMessageAsync(string topic, string groupId)
    {
        var config = new ConsumerConfig
        {
            GroupId = groupId,
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        var consumer = new ConsumerBuilder<string, string>(config).Build();
        consumer.Subscribe(topic);
        var consumeResult = consumer.Consume();
        return consumeResult.Message.Value;
    }

    public async Task ProduceMessageAsync(string topic, string message)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };
        var producer = new ProducerBuilder<string, string>(config).Build();
        await producer.ProduceAsync(topic, new Message<string, string> { Value = message });
    }
}