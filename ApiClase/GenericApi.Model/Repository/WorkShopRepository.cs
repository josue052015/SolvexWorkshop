using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Repository
{
  public class WorkShopRepository: Repository<WorkShop,GenericApiContext>
    {
        private readonly GenericApiContext _context;
        
        public WorkShopRepository(GenericApiContext context) : base(context)
        {
          
            this._context = context;
        }
       
        public async Task<List<WorkShop>> GetAll()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            var ok = _context.WorkShops.Where(x => x.Deleted == false).ToList();

            return ok;
    
        } 
        public async Task<WorkShop> Delete(int id)
        {
            var entity = await _context.WorkShops.FindAsync(id);
            if (entity == null) return entity;

            entity.Deleted = true;
            await _context.SaveChangesAsync();

            return entity;
        }

    }
}
