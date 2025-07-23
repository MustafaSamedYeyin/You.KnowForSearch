
namespace OllamaKafka;

public interface IOllamaMessageToKafka
{
  
    Task<bool> ProduceMessageToKafka();
}