using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeckSpace;
[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class DeckController : ControllerBase
{

    public IDeckService _deckService { get; set; }

    public DeckController(IDeckService deckService)
    {
        _deckService = deckService;
    }

    [HttpPost]
    public async Task<IActionResult> AddDeckAsync(Deck deck) => Ok(await _deckService.AddDeckAsync(deck));
    
    [HttpPut]
    public async Task<IActionResult> UpdateDeck(Deck deck) => Ok(await _deckService.UpdateDeckAsync(deck));
    
    [HttpGet]
    public async Task<IActionResult> GetDecksAsync() => Ok(await _deckService.GetAllDecksAsync());
    
    [HttpGet]
    public async Task<IActionResult> GetDeckByIdAsync(int deckId) => Ok(await _deckService.GetDeckByIdAsync(deckId));
    
    [HttpGet]
    public async Task<IActionResult> CreatesDeckFromOllama() => Ok(await _deckService.CreatesDeckFromOllama());
}
