using Confluent.Kafka;
using Test.English.WebAPI.Ollama;

namespace OllamaKafka;

public class OllamaMessageToKafka : IOllamaMessageToKafka
{

    public async Task<bool> ProduceMessageToKafka()
    {
        var ollamaService = new OllamaService();
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };
        var producer = new ProducerBuilder<string, string>(config).Build();

        await foreach (var answer in ollamaService.GetOllamaAnswer())
        {
            await producer.ProduceAsync("Deck", new Message<string, string> { Key = answer.DeckName, Value = answer.Question });
        }
        return true;
    }
}
