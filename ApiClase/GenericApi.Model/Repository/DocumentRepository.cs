using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Repository
{
   public class DocumentRepository : Repository<Document, GenericApiContext>
    {
        private readonly GenericApiContext _context;

        public DocumentRepository(GenericApiContext context) : base(context)
        {
            this._context = context;
        }


    }
}
