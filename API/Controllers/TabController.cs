using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TabSpace
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class TabController : ControllerBase
    {
        public ITabService _service { get; set; }
        public TabController(ITabService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() => Ok(await _service.GetAll());
        
        [HttpPost]
        public async Task<ActionResult> Add(Tab tab) => Ok(await _service.Add(tab));
        
        [HttpPut]
        public async Task<ActionResult> Update(Tab tab) => Ok(await _service.Update(tab));
        
        [HttpDelete]
        public async Task<ActionResult> Delete(int id) => Ok(await _service.Delete(id));

    }
}