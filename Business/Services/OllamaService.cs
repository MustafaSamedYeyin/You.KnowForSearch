using Core.Dto.Ollama;
using Core.Entities.Tabs;
using Core.Ollama;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;
using OllamaSharp;
using OllamaSharp.Models.Chat;
using System;
using System.Text;
using static Elastic.Clients.Elasticsearch.JoinField;

namespace Test.English.WebAPI.Ollama;

public class OllamaService : IOllamaService
{
    public List<string> DeckTopics()
    {
        return new List<string>
        {
            "Dockerfile keywords to search.",
            "docker-compose.yml keywords to search."
        };
    }

    public string GetOllamaQuestion(string topic, bool isSector = false, bool fullQuestion = false)
    {
        if (fullQuestion)
        {
            return String.Join(" ", new List<string>()
            {
                $"You have a maximum of 20 seconds to answer.",
                $"Give me 30 different questions I can ask ChatGPT about '{topic}'.",
                $"I will use a question about '{topic}' as curriculum.",
                $"Separate all questions with a '-' character.",
                $"You will create question sentence not works.",
                $"Give every question with outline.",
                $"Max Level outline should be 1 so do not nest items.",
                $"Min chars 50 max 125 chars.",
                $"Give exatly 30 questions for basic, intermediate, advanced.",
                $"Questions must start with '-' and only questions must start '-'.",
                $"I will parse questions by '-' sign.",
            });
        }

        if (isSector)
        {
            return String.Join(" ", new List<string>
            {
                $"Cevaplamak için en fazla 20 saniyen var.",
                $"Cevabın Türkçe olmalı.",
                $"\"{topic}\" konusu için Google'da aramak üzere 30 kelime ver.",
                $"\"{topic}\" konusundaki kelimeleri bitirdiğimde bir iş kurabilmeliyim.",
                $"Desteler üretiyorum, her deste bir \"{topic}\". Ve her destenin içinde Google'da aranacak kelimeler olmalı.",
                "Sadece taslak (outline) ver!",
                "Her madde en fazla 25 karakter olabilir!",
                "Paragraf ekleme, sadece outline şeklinde maddeler ver, ben C# uygulamamda işleyeceğim.",
                "Temelden ileri seviyeye doğru sıralanmalı, müfredat gibi olmalı.",
                "Elimde şöyle bir soru havuzu var:",
                "sorulardan biri: '{0}, {1} nedir?'",
                "sorulardan biri: 'DeepSeek {0}, {1}?'",
                "sorulardan biri: '{0}, {1} kim tarafından oluşturuldu?'",
                "sorulardan biri: '{0}, {1} tarihi?'",
                "sorulardan biri: '{0}, {1} örnekleri?'",
                "sorulardan biri: '{0}, {1} neden var?'",
                "sorulardan biri: '{0}, {1} ne zaman kullanılır?'",
                "sorulardan biri: 'Online topluluklar {0}, {1}?'",
                "sorulardan biri: '{0}, {1} neden gerekli?'",
                "sorulardan biri: '{0}, {1} ne zaman kullanılır?'",
                "sorulardan biri: '{0}, {1} ne zaman kullanılmaz?'",
                "sorulardan biri: '{0}, {1} nasıl öğrenilir?'",
                "sorulardan biri: '{0}, {1} nasıl çalışır?'",
                "sorulardan biri: '{0}, {1} nasıl denenir?'",
                "sorulardan biri: '{0}, {1} eleştirisi?'",
                "sorulardan biri: '{0}, {1} nasıl uygulanır?'",
                "sorulardan biri: '150 karakterle açıkla: {0}, {1}?'",
                "sorulardan biri: '450 karakterle açıkla: {0}, {1}?'",
                "sorulardan biri: '{0}, {1} öğrenmek için anahtar kelimeler listesi?'",
                "sorulardan biri: 'Uygulamalı öğrenmek için anahtar kelimeler: {0}, {1}?'",
                "sorulardan biri: '{0}, {1} ile farkları?'",
                "{0} ile değiştirilebilecek kelimeler arıyorum.",
                "Ek açıklama veya başlık ekleme.",
                "Çıktı şu formatta olmalı:",
                " ",
                @"  - kelime1
                    - kelime2
                    - kelime3
                    - kelime4
                    .
                    .
                    - kelime30
                    ",
            });

        }
        else
        {
            return String.Join(" ", new List<string>
            {
                $"You have max 20 seconds to answer.",
                $"Give me 30 words to search in google for \"{topic}\".",
                $"When I finish the word from \"{topic}\" I must able to pass interview.",
                $"I am generating decks, every deck is a : \"{topic}\" , And inside of every there must be words to search on google.",
                "Just give with outline!.",
                "For every item you just have 25 chars!.",
                "And do not add paragraphy just items with outline I will parse them in my c# application.",
                "Should be order from basics to advance like curriculum.",
                "I have question pool like that : ",
                "one of question : 'What is {0}, {1}?'",
                "one of question : 'DeepSeek {0}, {1}?'",
                "one of question : 'Who created {0}, {1}?'",
                "one of question : 'History Of {0}, {1}?'",
                "one of question : 'Examples of {0}, {1}?'",
                "one of question : 'Why Exist {0}, {1}?'",
                "one of question : 'Decide when to use {0}, {1}?'",
                "one of question : 'OnlineCommunities {0}, {1}?'",
                "one of question : 'Why need {0}, {1}?'",
                "one of question : 'When To Use {0}, {1}?'",
                "one of question : 'When Not To Use {0}, {1}?'",
                "one of question : 'How to learn {0}, {1}?'",
                "one of question : 'How Its Working {0}, {1}?'",
                "one of question : 'How To Try {0}, {1}?'",
                "one of question : 'Critise {0}, {1}?'",
                "one of question : 'Implement {0}, {1}?'",
                "one of question : 'Explain With 150 Chars {0}, {1}?'",
                "one of question : 'Explain 450 Chars {0}, {1}?'",
                "one of question : 'List Keywords To Learn {0}, {1}?'",
                "one of question : 'List Keywords To Learn With Practice {0}, {1}?'",
                "one of question : 'Differentiate with {0}, {1}?'",
                "I am looking for words to replace with {0}",
                "Do not add extra explanation or header.",
                "Output should be like that : ",
                " ",
                @"  - word1
                    - word2
                    - word3
                    - word4
                    .
                    .
                    - word30
                    ",
            });
        }
    }

    public async IAsyncEnumerable<OllamaAnserDTO?> GetOllamaAnswer()
    {
        foreach (var decktopic in DeckTopics())
        {
            var question = GetOllamaQuestion(decktopic,true,true);

            OllamaService ollamaService = new OllamaService();

            yield return new OllamaAnserDTO()
            {
                Question = await ollamaService.SendMessageToOllama(new List<string> { question }),
                DeckName = decktopic
            };
        }
    }

    public async Task<string> SendMessageToOllama(List<string> args)
    {
        try
        {
            var uri = new Uri("http://localhost:11434");

            var ollama = new OllamaApiClient(uri);

            ollama.SelectedModel = "deepseek-r1";

            var chat = new Chat(ollama);

            chat.Messages = args.Select(i => new Message
            {
                Content = i,
                Role = ChatRole.Assistant
            }).ToList();

            var text = new StringBuilder();

            await foreach (var answerToken in chat.SendAsync(String.Join(' ', args)))
            {
                text.Append(answerToken);
            }
            return text.ToString();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<string> ExtractWordFromOllamaResult(string result)
    {
        var splitChar = '-';
        var firstStartWord = result.Replace(" ", string.Empty).IndexOf(splitChar) + 1;
        var plainWords = result.Substring(firstStartWord > 1 ? firstStartWord :0);
        var worldList = plainWords.Split("\n");
        return worldList.Select(i =>
        {
            var splitCharIndex = i.IndexOf(splitChar) + 1;
            var startIndex = splitCharIndex > 1 ? splitCharIndex : 0;
            return i.Substring(startIndex).Trim();
        }).ToList();
    }
}