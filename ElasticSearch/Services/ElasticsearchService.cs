
using Nest;

namespace Elasticsearch.Services{
    public class ElasticsearchService<T>: IElasticsearchService<T> where T:class
    {
        private readonly ElasticClient _elasticClient;
        public ElasticsearchService(ElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<string> CreateDocumentAsync(T document)
        {
            var response = await _elasticClient.IndexDocumentAsync(document);
            return response.IsValid ? "Document Created Successfully":"Document creation failed!";
        }

        public async Task<string> DeleteDocumentAsync(string id)
        {
            var response = await _elasticClient.DeleteAsync(new DocumentPath<T>(id));
            return response.IsValid ? "Document Deleted Successfully":"Document Deletion failed!";
        }

        public async Task<IEnumerable<T>> GetAllDocuments()
        {
            var response = await _elasticClient.SearchAsync<T>(s=>s.MatchAll().Size(10000));
            return response.Documents;
        }

        public async Task<T> GetDocumentAsync(string id)
        {
            var response = await _elasticClient.GetAsync(new DocumentPath<T>(id));
            return response.Source;
        }

        public async Task<string> UpateDocumentAsync(T document)
        {
            var response = await _elasticClient.UpdateAsync(new DocumentPath<T>(document),u=>u.Doc(document).RetryOnConflict(3));
            return response.IsValid ? "Document Updated Successfully":"Document updation failed!";
        }
    }
}