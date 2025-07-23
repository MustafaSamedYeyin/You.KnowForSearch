
namespace QuestionSpace
{
    public interface IQuestionTabService
    {
        Task<QuestionTab> Add(QuestionTab entity);
        Task<bool> Delete(int id);
        Task<QuestionTab> Update(QuestionTab entity);
        Task<IEnumerable<QuestionTab>> GetAll();
    }
}
