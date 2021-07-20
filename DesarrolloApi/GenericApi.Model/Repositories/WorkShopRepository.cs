using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Repositories
{
    public interface IWorkShopRepository : IBaseRepository<WorkShop> { }
    class WorkShopRepository : BaseRepository<WorkShop>, IWorkShopRepository
    {
        public WorkShopRepository(WorkShopContext context): base(context)
        {

        }
    }
}
