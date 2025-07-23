using QuestionSpace;
using TabSpace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace QuestionSpace
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        public IQuestionsService _service { get; set; }

        public QuestionsController(IQuestionsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetByQuestionTab([FromQuery]Tab tab) => Ok(await _service.GetByTab(tab));
        
        [HttpPost]
        public async Task<ActionResult> Add(Question question) => Ok(await _service.Add(question));
        
        [HttpPut]
        public async Task<ActionResult> Update(Question question) => Ok(await _service.Update(question));
        
        [HttpDelete]
        public async Task<ActionResult> Delete(int id) => Ok(await _service.Delete(id));

    }
}
