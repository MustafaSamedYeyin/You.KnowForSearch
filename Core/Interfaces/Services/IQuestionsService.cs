using TabSpace;
namespace QuestionSpace
{
    public interface IQuestionsService
    {
        Task<Question> Add(Question entity);
        Task<bool> Delete(int id);
        Task<Question> Update(Question entity);
        Task<List<Question>> GetByTab(Tab tab);
        Task<Question> GetById(int id);
        Task<List<Question>> GetAll();
    }
}