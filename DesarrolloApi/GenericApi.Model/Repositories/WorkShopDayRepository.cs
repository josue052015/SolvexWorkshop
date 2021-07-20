using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Repositories
{
    public interface IWorkShopDayRepository : IBaseRepository<WorkShopDay> { }
    class WorkShopDayRepository : BaseRepository<WorkShopDay>, IWorkShopDayRepository
    {
        public WorkShopDayRepository(WorkShopContext context) : base (context)
        {

        }
    }
}
