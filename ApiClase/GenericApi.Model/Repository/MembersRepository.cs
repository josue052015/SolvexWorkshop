using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Repository
{
   public class MembersRepository: Repository<WorkShopMember, GenericApiContext>
    {
        private readonly GenericApiContext _context;

        public MembersRepository(GenericApiContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<List<WorkShopMember>> GetAll()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            var workShopMembersData = _context.workShopMembers.Where(x => x.Deleted == false).ToList();

            return workShopMembersData;

        }
        public async Task<WorkShopMember> Delete(int id)
        {
            var entity = await _context.workShopMembers.FindAsync(id);
            if (entity == null) return entity;

            entity.Deleted = true;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
