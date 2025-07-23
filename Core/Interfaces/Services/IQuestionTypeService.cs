using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionSpace
{
    public interface IQuestionTypeService
    {
        Task<QuestionType> Add(QuestionType entity);
        Task<bool> Delete(int id);
        Task<QuestionType> Update(QuestionType entity);
        Task<QuestionType> GetById(int id);
        Task<IEnumerable<QuestionType>> GetAll();
    }
}
