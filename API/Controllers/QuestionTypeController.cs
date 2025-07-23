using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuestionSpace
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class QuestionTypeController : ControllerBase
    {
        public IQuestionTypeService _service { get; set; }

        public QuestionTypeController(IQuestionTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() => Ok(await _service.GetAll());
        
        [HttpPost]
        public async Task<ActionResult> Add(QuestionType questionType) => Ok(await _service.Add(questionType));
        
        [HttpPut]
        public async Task<ActionResult> Update(QuestionType questionType) => Ok(await _service.Update(questionType));
        
        [HttpDelete]
        public async Task<ActionResult> Delete(int id) => Ok(await _service.Delete(id));

    }
}
