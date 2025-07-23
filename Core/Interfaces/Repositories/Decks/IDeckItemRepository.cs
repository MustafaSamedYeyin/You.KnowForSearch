using DeckSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckSpace;
public interface IDeckItemRepository
{
    Task<List<Word>> GetDeckItemsAsync(int id);
}
