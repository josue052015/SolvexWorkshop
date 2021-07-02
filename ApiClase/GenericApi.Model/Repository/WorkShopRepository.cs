using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Model.Repository
{
  public class WorkShopRepository: Repository<WorkShop,GenericApiContext>
    {
        public WorkShopRepository(GenericApiContext context) : base(context)
        {
           
        }
    }
}
