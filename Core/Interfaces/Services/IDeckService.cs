using DeckSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckSpace;
public interface IDeckService
{
    Task<int> AddDeckAsync(Deck deck);
    Task<bool> UpdateDeckAsync(Deck deck);
    Task<IEnumerable<Deck>> GetAllDecksAsync();
    Task<Deck> GetDeckByIdAsync(int deckId);
    Task<Deck> GetDeckByNameAsync(string name);
    Task<bool> CreatesDeckFromOllama();
}