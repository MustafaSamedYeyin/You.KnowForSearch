using QuestionSpace;

namespace ElasticSearchSpace
{
    public interface IElasticSearchQuestionService : IElasticSearchService<Question, ElasticsearchDto<Question>>
    {
    }
}
