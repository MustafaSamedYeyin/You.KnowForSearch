using Core.Entities.Bases;
using TabSpace;

namespace QuestionSpace
{
    public class QuestionTab : AggregateRoot
    {
        public Question Questions { get; set; }
        public Tab Tabs { get; set; }
        public int QuestionId { get; set; }
        public int TabId { get; set; }
    }
}
