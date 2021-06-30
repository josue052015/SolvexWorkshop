using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericApi.Model.Repository
{
   public interface IWorkShopRepository
    {
        IEnumerable<WorkShop> GetWorkShops();
        Task<WorkShop> GetById(int id);
        
    }
}
