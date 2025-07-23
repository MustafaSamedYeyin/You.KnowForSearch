
namespace QuestionSpace
{
    public class QuestionTypeService : IQuestionTypeService
    {
        public IQuestionTypeRepository _repo { get; set; }

        public QuestionTypeService(IQuestionTypeRepository service)
        {
            _repo = service;
        }

        public async Task<QuestionType> Add(QuestionType entity)
        {
            return await _repo.AddAsync(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<IEnumerable<QuestionType>> GetAll()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<QuestionType> GetById(int id)
        {
            return await _repo.GetByIdAsync(id);
        }


        public async Task<QuestionType> Update(QuestionType entity)
        {
             return await _repo.Update(entity);
        }
    }
}
