using Data.Repositories;
using Data.Repositories.Context;
using QuestionSpace;

namespace QuestionSpace
{
    public class QuestionTypeRepository : GenericRepository<QuestionType>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(YouDbContext youRepo) : base(youRepo)
        {
        }
    }
}
