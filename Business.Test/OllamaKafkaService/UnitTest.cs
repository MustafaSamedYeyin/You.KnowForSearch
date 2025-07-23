using Business.Services;
using OllamaKafka;
using System.Threading.Tasks;

namespace Business.Test;

public class UnitTest
{
    [Fact]
    public async Task Test1()
    {
        OllamaMessageToKafka ollamaMessageToKafka = new OllamaMessageToKafka();
    }
}