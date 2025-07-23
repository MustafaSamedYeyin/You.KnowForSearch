using QuestionSpace;

namespace ElasticSearchSpace
{
    public interface IElasticSearchService<T,M> where T : class where M : ElasticsearchDto<T>
    {
        Task IndexDocumentAsync(M document);
        Task<T?> GetDocumentByIdAsync(ElasticsearchDto<Question> questions);
        Task<T?> CreateDocumentAsync(M question);
        Task DeleteDocumentAsync(ElasticsearchDto<Question> search);
        Task<IEnumerable<T>> SearchAsync(M indexName, string query);
    }
}
