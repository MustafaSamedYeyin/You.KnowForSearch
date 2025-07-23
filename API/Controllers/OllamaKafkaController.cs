using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OllamaKafka;
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class OllamaKafkaController : ControllerBase
{
    public IOllamaKafkaService _messageToKafka { get; set; }

    public OllamaKafkaController(IOllamaKafkaService messageToKafka)
    {
        _messageToKafka = messageToKafka;
    }

    public string Topic { get; set; } = "Ollama";

    [HttpPost]
    public async Task<IActionResult> PostMessageToKafkaWithOllama(PostMessageToKafkaWithOllamaDto postMessage) 
        => Ok(await _messageToKafka.ProduceMessageAsync(Topic, postMessage.Text));

    [HttpGet]
    public async Task<IActionResult> GetMessageToDbFromKafka() 
        => Ok(await _messageToKafka.ConsumeMessageAsync(Topic));
}
