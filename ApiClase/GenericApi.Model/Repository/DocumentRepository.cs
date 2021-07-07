using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Repository
{
   public class DocumentRepository : IDocumentRepository
    {
        private readonly GenericApiContext _context;

        public DocumentRepository(GenericApiContext context) 
        {
            this._context = context;
        }

        public async Task<Document> Create(Document document)
        {
            _context.Add(document);
            await _context.SaveChangesAsync();
            return document;
        }

        public async Task<Document> Delete(int id)
        {
           var entity = await _context.Documents.FindAsync(id);
            if (entity == null) return entity;

            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<Document>> GetAllDocuments()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            var documentData = _context.Documents.ToList();
            return documentData;
        }

        public async Task<Document> GetById(int id)
        {
            return await _context.Documents.FindAsync(id);
        }

        public async Task<Document> Update(int id,Document document)
        {
           var documentExist = await _context.Documents.FindAsync(id);
            if (documentExist == null) return document;

            _context.Entry(document).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return document;
        }
    }
}
