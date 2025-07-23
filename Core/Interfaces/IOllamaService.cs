using Core.Dto.Ollama;

namespace Core.Ollama;
public interface IOllamaService
{
    List<string> DeckTopics();
    IEnumerable<string> ExtractWordFromOllamaResult(string result);
    IAsyncEnumerable<OllamaAnserDTO?> GetOllamaAnswer();
    string GetOllamaQuestion(string topic,bool isSector = false, bool fullQuestion = false);
    Task<string> SendMessageToOllama(List<string> args);
}