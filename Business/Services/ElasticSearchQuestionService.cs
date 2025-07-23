using Core.Dto;
using Core.Exceptions.ElasticExceptions;
using Elastic.Clients.Elasticsearch;
using QuestionSpace;

namespace ElasticSearchSpace
{
    public class ElasticSearchQuestionService : IElasticSearchQuestionService
    {
        public ElasticsearchClient _client { get; set; }

        public ElasticSearchQuestionService(ElasticsearchClient client)
        {
            _client = client;
        }

        public async Task IndexDocumentAsync(ElasticsearchDto<Question> document)
        {
            var response = await _client.IndexAsync(document, i => i.Index(document.Index).Id(document.Keyword));

            if (!response.IsSuccess())
            {
                throw new NotSuccesfullException();
            }
        }

        public async Task<Question?> GetDocumentByIdAsync(ElasticsearchDto<Question> search)
        {
            var result = await _client.GetAsync<Question>(new GetRequest(search.Index, search.Data.Id));
            return search.Data;
        }

        public async Task<Question?> CreateDocumentAsync(ElasticsearchDto<Question> search)
        {
            await _client.CreateAsync(new CreateRequest<Question>(search.Data, search.Index, search.Data.Id));
            return search.Data;
        }

        public async Task DeleteDocumentAsync(ElasticsearchDto<Question> search)
        {
            await _client.DeleteAsync(new DeleteRequest(search.Index, search.Data.Id));
        }

        public async Task<IEnumerable<Question>> SearchAsync(ElasticsearchDto<Question> search, string query)
        {
            var searchResponse = await _client.SearchAsync<Question>(s => s
                                .Indices(search.Index)
                                .Query(q => q.QueryString(qs => qs.Query(query))));

            return searchResponse.Documents;
        }
    }
}