using GenericApi.Core.BaseModel;
using GenericApi.Model.Contexts;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Repository
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IBaseEntity
        where TContext : DbContext
    {
        private readonly TContext context;


        public Repository(TContext context)
        {
            this.context = context;
        }
        public async Task<List<TEntity>> GetAll()
        {
            //TODO: que retorne solo cuando la propiedad sea true

             return await context.Set<TEntity>().ToListAsync();
        
        }

        
        public async Task<TEntity> GetById(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
           
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;

        }

       

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

       
    }
}
