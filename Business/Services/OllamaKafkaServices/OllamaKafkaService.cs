using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OllamaKafka;
public class OllamaKafkaService : IOllamaKafkaService
{

    public IKafkaMessageToDb _kafkaMessageToDb;
    public IOllamaMessageToKafka _ollamaMessageToKafka;

    public OllamaKafkaService(IKafkaMessageToDb kafkaMessageToDb, IOllamaMessageToKafka ollamaMessageToKafka)
    {
        _kafkaMessageToDb = kafkaMessageToDb;
        _ollamaMessageToKafka = ollamaMessageToKafka;
    }

    public async Task<bool> ConsumeMessageAsync(string topic)
    {
        return await _kafkaMessageToDb.SaveKafkaMessageToDb();
    }

    public async Task<bool> ProduceMessageAsync(string topic, string message)
    {
        return await _ollamaMessageToKafka.ProduceMessageToKafka();
    }
}
