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
    public class WorkShopController<TEntity, TRepository> : ControllerBase
        where TEntity : WorkShop, IBaseEntity
        where TRepository : IRepository<TEntity>
      
    {
        public readonly TRepository repository;

        public WorkShopController(TRepository repository)
        {
            this.repository = repository;

            // _GenericApiContext = genericApiContext;
        }

        [HttpGet]
        //public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        //{
        //   return await repository.GetAll();

        //}
        public ActionResult Get()
        {
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult GetId()
        {
            return Ok();

        }
        [HttpPost]
        public ActionResult Post()
        {
            return NoContent();

        }
    }
}



//public WorkShopController(IRepository<WorkShop> repository, GenericApiContext genericApiContext)
//{
//    _repository = repository;
//    _GenericApiContext = genericApiContext;
//}