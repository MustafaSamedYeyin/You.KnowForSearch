using Confluent.Kafka;
using Core.Dto.Ollama;
using DeckSpace;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.English.WebAPI.Ollama;
namespace OllamaKafka;

public class KafkaMessageToDb : IKafkaMessageToDb
{
    public IDeckService _deckService { get; set; }
    public string Topic { get; set; } = "Deck";

    public KafkaMessageToDb(IDeckService deckService)
    {
        _deckService = deckService;
    }

    public List<OllamaAnserDTO> GetKafkaMessage()
    {
        var ollamaService = new OllamaService();
        var config = new ConsumerConfig
        {
            GroupId = "DeckConsumers",
            BootstrapServers = "localhost:9092",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
        var consumer = new ConsumerBuilder<string, string>(config).Build();
        consumer.Subscribe(Topic);
        var consumeResult = consumer.Consume();

        var result = ollamaService.ExtractWordFromOllamaResult(consumeResult.Message.Value);
        return result.Select(i => new OllamaAnserDTO()
        {
            Question = i,
            DeckName = consumeResult.Message.Key
        }).ToList();
    }

    public async Task<bool> SaveKafkaMessageToDb()
    {
        var kafkaMessages = GetKafkaMessage();
        foreach (var kafkaMessage in kafkaMessages)
        {
            while (kafkaMessage != null)
            {
                var deck = await _deckService.GetDeckByNameAsync(kafkaMessage.DeckName);

                if (deck != null)
                {
                    if (deck.Words != null)
                    {
                        foreach (var word in deck.Words)
                        {
                            if (word.Text == kafkaMessage.Question)
                            {
                                return false;
                            }
                        }
                    }

                    deck.Words.Add(new Word { Text = kafkaMessage.Question });
                    await _deckService.UpdateDeckAsync(deck);
                }
                else
                {
                    deck = new Deck
                    {
                        Text = kafkaMessage.DeckName,
                        Words = new List<Word>
                        {
                            new Word { Text = kafkaMessage.Question }
                        }
                    };
                    await _deckService.AddDeckAsync(deck);
                }
            }
            kafkaMessages = GetKafkaMessage();
        }
        return true;
    }
}