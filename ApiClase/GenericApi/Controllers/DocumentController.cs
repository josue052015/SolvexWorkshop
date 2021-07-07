using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericApi.Model.Repository;
using GenericApi.Model.Entities;

namespace GenericApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _repository;

        public DocumentController(IDocumentRepository repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        public async Task<List<Document>> GetAllDocuments()
        {
            return await _repository.GetAllDocuments();
        }

        [HttpGet("{id}")]
        public async Task<Document> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost]
        public async Task<Document> Create(Document document)
        {
            return await _repository.Create(document);
        }

        [HttpPut("{id}")]
        public async Task<Document> Update(int id, Document document)
        {
            
            return await _repository.Update(id, document);
        }

        [HttpDelete("{id}")]
        public async Task<Document> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
