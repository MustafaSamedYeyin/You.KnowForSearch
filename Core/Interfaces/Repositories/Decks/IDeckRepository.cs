using DeckSpace;

namespace DeckSpace;
public interface IDeckRepository
{
    Task<Deck> GetDeckByIdAsync(int id);
    Task<IEnumerable<Deck>> GetAllDecksAsync();
    Task<int> AddDeckAsync(Deck deck);
    Task<Deck> GetDeckByNameAsync(string name);
    Task<bool> UpdateDeckAsync(Deck deck);
    Task DeleteDeckAsync(int id);
}