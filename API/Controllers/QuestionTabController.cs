using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuestionSpace
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class QuestionTabController : ControllerBase
    {
        
    }
}
