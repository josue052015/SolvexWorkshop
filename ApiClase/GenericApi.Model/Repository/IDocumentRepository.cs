using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Repository
{
     public interface IDocumentRepository
    {
        Task<List<Document>> GetAllDocuments();
        Task<Document> GetById(int id);
         Task<Document> Create(Document document);
        Task<Document> Update(int id, Document document);
        Task<Document> Delete(int id);
    }
}
