namespace Elasticsearch.Services{
    public interface IElasticsearchService<T>{
        Task<string> CreateDocumentAsync(T document);
        Task<T> GetDocumentAsync(string id);
        Task<IEnumerable<T>> GetAllDocuments();
        Task<string> UpateDocumentAsync(T document);
        Task<string> DeleteDocumentAsync(string id);
    }
}