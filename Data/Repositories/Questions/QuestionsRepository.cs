using Data.Repositories;
using Data.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using TabSpace;

namespace QuestionSpace
{
    public class QuestionsRepository : GenericRepository<Question>, IQuestionsRepository
    {
        public QuestionsRepository(YouDbContext context) : base(context) { }


        public async Task<Question> Add(Question entity)
        {
            _context.Questions.Add(entity);
            return await SaveChangesAsync(entity);
        }

        public async Task<Question> Delete(int id)
        {
            var question = await GetById(id);

            _context.Questions.Remove(question);

            return await SaveChangesAsync(question);
        }

        public async Task<List<Question>> GetAll()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetById(int id)
        {
            var question = await _context.Questions.FirstAsync(i => i.Id == id);
            return question;
        }

        public async Task<List<Question>> GetByTab(Tab tab)
        {
            var questions = await _context.Questions.Join(_context.QuestionTabs, i => i.Id, i => i.QuestionId, (q, qt) => new
            {
                q.Id,
                q.CreateTime,
                q.UpdateTime,
                q.IsActive,
                q.QuestionFormat,
                q.Sort,
                q.QuestionType,
                QuestionTabId = qt.TabId
            }).Join(_context.Tabs, i => i.QuestionTabId, i => i.Id, (rt, t) => new
            {
                rt.Id,
                rt.CreateTime,
                rt.UpdateTime,
                rt.IsActive,
                rt.QuestionFormat,
                rt.Sort,
                rt.QuestionType,
                QuestionTabId = t.Id,
                TabId = t.Id
            }).Where(i => i.TabId == tab.Id).Select(q => new Question()
            {
                Id = q.Id,
                CreateTime = q.CreateTime,
                UpdateTime = q.UpdateTime,
                IsActive = q.IsActive,
                QuestionFormat = q.QuestionFormat,
                Sort = q.Sort,
                QuestionType = q.QuestionType,
            }).ToListAsync();

            return questions;
        }

        public async Task<Question> Update(Question entity)
        {
            var question = await GetById(entity.Id);

            question.Update(entity.QuestionFormat, question.Sort);

            _context.Questions.Update(question);

            return await SaveChangesAsync(entity);
        }

        public async Task<Question> SaveChangesAsync(Question question)
        {
            await _context.SaveChangesAsync();
            return question;
        }
    }
}
