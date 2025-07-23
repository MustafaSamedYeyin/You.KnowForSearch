using Core.Interfaces.Repositories;
using TabSpace;

namespace QuestionSpace
{
    public interface IQuestionsRepository : IGenericRepository<Question>
    {
        Task<List<Question>> GetAll();
        Task<Question> GetById(int id);
        Task<List<Question>> GetByTab(Tab tab);
        Task<Question> SaveChangesAsync(Question question);

    }
}
