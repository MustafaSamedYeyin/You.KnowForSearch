using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Bases;
using Core.Enums;

namespace QuestionSpace
{
    public class QuestionType : AggregateRoot
    {
        public QuestionTypeEnum Type { get; set; }
        public List<Question> Questions { get; set; }
    }
}
