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
        private readonly WorkShopRepository _repository;

        public WorkShopController(WorkShopRepository repository) : base(repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkShop>>> Get()
        {
            var workshopResult = _repository.GetAll();
           
            return await workshopResult;
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
           
            return NoContent();
        }
    }
}




