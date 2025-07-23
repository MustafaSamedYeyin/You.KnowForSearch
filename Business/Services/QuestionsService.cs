using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using TabSpace;
using ElasticSearchSpace;

namespace QuestionSpace
{
    public class QuestionsService : IQuestionsService
    {
        public IQuestionsRepository _repo { get; set; }
        //public IElasticSearchQuestionService _elasticSearchQuestionService { get; set; }
        public IConfiguration _configuration { get; set; }
        //public IRedisSessionService _redisSession { get; set; }
        public IKafkaService _kafkaService { get; set; }

        public QuestionsService(IQuestionsRepository repo, /*IElasticSearchQuestionService elasticSearchService,*/
        /*IRedisSessionService redisSession,*/ IConfiguration configuration, IKafkaService kafkaService)
        {
            _repo = repo;
            //_elasticSearchQuestionService = elasticSearchService;
            //_redisSession = redisSession;
            _configuration = configuration;
            _kafkaService = kafkaService;
        }

        public async Task<Question> Add(Question entity)
        {
            return await _repo.AddAsync(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _repo.Delete(id);
        }

        public async Task<List<Question>> GetAll()
        {
            var results = await _repo.GetAll();

            return results;
        }

        public async Task<Question> GetById(int id)
        {
            return await _repo.GetById(id);
        }

        public async Task<List<Question>> GetByTab(Tab tab)
        {
            var results = await _repo.GetByTab(tab);
            
            return results.OrderBy(i => i.Sort).ToList();
        }

        public async Task<Question> Update(Question entity)
        {
            return await _repo.Update(entity);
        }
    }
}
