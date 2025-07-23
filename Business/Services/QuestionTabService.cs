using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionSpace
{
    public class QuestionTabService : IQuestionTabService
    {
        public IQuestionTabRepository _repo { get; set; }

        public QuestionTabService(IQuestionTabRepository repo)
        {
            _repo = repo;
        }

        public async Task<QuestionTab> Add(QuestionTab entity)
        {
            return await _repo.AddAsync(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<IEnumerable<QuestionTab>> GetAll()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<QuestionTab> GetById(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<QuestionTab> Update(QuestionTab entity)
        {
            return await _repo.Update(entity);
        }
    }
}
