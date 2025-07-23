using Data.Repositories;
using Data.Repositories.Context;

namespace QuestionSpace
{
    public class QuestionTabRepository : GenericRepository<QuestionTab>, IQuestionTabRepository
    {
        public QuestionTabRepository(YouDbContext youRepo) : base(youRepo)
        {
        }
    }
}
