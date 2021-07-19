using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Repository
{
  public class WorkShopDayRepository : Repository<WorkShopDay, GenericApiContext>
    {
        private readonly GenericApiContext _context;

        public WorkShopDayRepository(GenericApiContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<WorkShopDay>> GetAll()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            var workShopDayData = _context.WorkShopDays.Where(x => x.Deleted == false).ToList();

            return workShopDayData;

        }
        public async Task<WorkShopDay> Delete(int id)
        {
            var entity = await _context.WorkShopDays.FindAsync(id);
            if (entity == null) return entity;

            entity.Deleted = true;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
