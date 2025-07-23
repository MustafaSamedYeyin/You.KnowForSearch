using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeckSpace;
[Route("api/[controller]/[action]")]
[Authorize]
[ApiController]
public class DeckItemController : ControllerBase
{
    public IDeckItemService _service { get; set; }

    public DeckItemController(IDeckItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetDeckItemsAsync(int id) => Ok(await _service.GetDeckItemsAsync(id));
}