using DeckSpace;

namespace DeckSpace;

public class DeckItemService : IDeckItemService
{
    public IDeckItemRepository _repository { get; set; }

    public DeckItemService(IDeckItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Word>> GetDeckItemsAsync(int id)
    {
        return await _repository.GetDeckItemsAsync(id);
    }
}
