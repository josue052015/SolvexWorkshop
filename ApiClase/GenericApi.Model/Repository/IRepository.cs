using GenericApi.Core.BaseModel;
using GenericApi.Model.Entities;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Repository
{
   public interface IRepository<T> where T : class, IBaseEntity
    {
        
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
    
    }
}
