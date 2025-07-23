using Core.Dto.Ollama;

namespace OllamaKafka;
public interface IKafkaMessageToDb
{
    List<OllamaAnserDTO> GetKafkaMessage();
    Task<bool> SaveKafkaMessageToDb();
}