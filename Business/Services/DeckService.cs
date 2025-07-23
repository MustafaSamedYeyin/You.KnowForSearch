using Core.Ollama;

namespace DeckSpace;

public class DeckService : IDeckService
{
    public IDeckRepository _deckRepository { get; set; }
    public IOllamaService _ollamaService { get; set; }

    public DeckService(IDeckRepository deckRepository, IOllamaService ollamaService)
    {
        _deckRepository = deckRepository;
        _ollamaService = ollamaService;
    }

    public async Task<int> AddDeckAsync(Deck deck)
    {
        return await _deckRepository.AddDeckAsync(deck);
    }

    public async Task<Deck> GetDeckByIdAsync(int deckId)
    {
        return await _deckRepository.GetDeckByIdAsync(deckId);
    }

    public async Task<IEnumerable<Deck>> GetAllDecksAsync()
    {
        return await _deckRepository.GetAllDecksAsync();
    }

    public async Task<bool> UpdateDeckAsync(Deck deck)
    {
        return await _deckRepository.UpdateDeckAsync(deck);
    }

    public async Task<Deck> GetDeckByNameAsync(string name)
    {
        return await _deckRepository.GetDeckByNameAsync(name);
    }

    public async Task<bool> CreatesDeckFromOllama()
    {
        var topics = _ollamaService.DeckTopics();
        
        foreach (var topic in topics)
        {
            var question = _ollamaService.GetOllamaQuestion(topic,false,false);

            var ollamaMessageResult = await _ollamaService.SendMessageToOllama(new List<string>() { question });

            var words = _ollamaService.ExtractWordFromOllamaResult(ollamaMessageResult);

            var results = await GetDeckByNameAsync(topic);

            var dbWordsDict = results!= null ? results.Words.ToDictionary(i => i.Text) : new Dictionary<string, Word>();


            var deck = new Deck()
            {
                Text = topic,
                Words = words.Select((word) =>
                {
                    var alreadyExistCheck = new Word();
                    dbWordsDict.TryGetValue(word, out alreadyExistCheck);
                    if (alreadyExistCheck != null)
                    {
                        return alreadyExistCheck;
                    }
                    else
                    {
                        return new Word { Text = word };
                    }
                }).ToList()
            };

            if (results != null)
            {
                deck.Words.AddRange(results.Words);
            }

            if (results != null)
            {
                deck.Id = results.Id;
                deck.Text = results.Text;
                await UpdateDeckAsync(deck);
            }
            else
            {
                await AddDeckAsync(deck);
            }
        }
        
        return true;
    }

}