using Elasticsearch.Models;
using Elasticsearch.Services;
using Microsoft.AspNetCore.Mvc;

namespace Elasticsearch.Controllers{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController:ControllerBase{
        private readonly IElasticsearchService<Author> _elasticsearchService;
        public HomeController(IElasticsearchService<Author> elasticsearchService)
        {
            _elasticsearchService = elasticsearchService;
        }
    [HttpGet]
    public async Task<IActionResult> GetAllDocuments(){
        var response = await _elasticsearchService.GetAllDocuments();
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDocument([FromBody] Author author){
        var response = await _elasticsearchService.CreateDocumentAsync(author);
        return Ok(response);
    }

    [HttpGet]
    [Route("read/{id}")]
    public async Task<IActionResult> GetDocument(string id){
        var response = await _elasticsearchService.GetDocumentAsync(id);
        if(response==null){
            return NotFound();
        }
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDocument([FromBody] Author author){
        var response = await _elasticsearchService.UpateDocumentAsync(author);
        return Ok(response);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public async Task<IActionResult> DeleteDocument(string id){
        var response = await _elasticsearchService.DeleteDocumentAsync(id);
        if(response==null){
            return NotFound();
        }
        return Ok(response);
    }
    }
}