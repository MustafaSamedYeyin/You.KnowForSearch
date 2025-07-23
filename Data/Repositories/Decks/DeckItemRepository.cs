using Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace DeckSpace;

public class DeckItemRepository : IDeckItemRepository
{
    public YouDbContext _context { get; set; }
    public DbSet<Word> _entity { get; set; }

    public DeckItemRepository(YouDbContext context)
    {
        _context = context;
        _entity = _context.Set<Word>();
    }

    public async Task<List<Word>> GetDeckItemsAsync(int id)
    {
        var result = await _entity.Where(i => i.DeckId == id).ToListAsync();
        return result;
    }
}