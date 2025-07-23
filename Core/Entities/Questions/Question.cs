using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Bases;

namespace QuestionSpace
{
    public class Question : AggregateRoot
    {
        public string QuestionFormat { get; set; }
        public double Sort { get; set; }
        public QuestionType? QuestionType { get; set; }
        public int? QuestionTypeId { get; set; }

        public Question Update(string questionFormat, double sort)
        {
            QuestionFormat = questionFormat;
            Sort = sort;
            return this;
        }
    }
}
