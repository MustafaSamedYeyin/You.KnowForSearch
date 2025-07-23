using Core.Entities.Bases;

namespace DeckSpace;

public class Deck : AggregateRoot
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<Word> Words { get; set; } = new List<Word>();
}