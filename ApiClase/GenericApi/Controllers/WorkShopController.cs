using GenericApi.Core.BaseModel;
using GenericApi.Model.Contexts;
using GenericApi.Model.Entities;
using GenericApi.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WorkShopController : BaseController<WorkShop, WorkShopRepository>
    {
        public WorkShopController(WorkShopRepository repository) : base(repository)
        {

        }
    }
}




