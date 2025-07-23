using DeckSpace;
using Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace DeckSpace;
public class DeckRepository : IDeckRepository
{
    public YouDbContext _context { get; set; }

    public DeckRepository(YouDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddDeckAsync(Deck deck)
    {
        var result = await _context.AddAsync(deck);
        await _context.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task DeleteDeckAsync(int id)
    {
        _context.Remove(new Deck { Id = id });
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Deck>> GetAllDecksAsync()
    {
        return await _context.Decks.ToListAsync();
    }

    public async Task<Deck> GetDeckByIdAsync(int id)
    {
        return await _context.Decks.FirstOrDefaultAsync(i=> i.Id == id);
    }

    public async Task<Deck> GetDeckByNameAsync(string name)
    {
        var result = await _context.Decks.FirstOrDefaultAsync(i=> i.Text == name);
        if (result != null)
        {
            _context.Entry(result).State = EntityState.Detached;
        }
        return result;
    }

    public async Task<bool> UpdateDeckAsync(Deck deck)
    {
        _context.Update(deck);
        await _context.SaveChangesAsync();
        return true;
    }
}