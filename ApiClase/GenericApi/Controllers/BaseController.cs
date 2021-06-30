using GenericApi.Core.BaseModel;
using GenericApi.Model.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Controllers
{
   
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity: class, IBaseEntity
        where TRepository: IRepository<TEntity>
    {
        private readonly TRepository repository;

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var WorkShop = await repository.GetById(id);
            if (WorkShop == null) return NotFound();
            
            return WorkShop;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity workShop)
        {
            if (id != workShop.Id)
            {
                return BadRequest();
            }
            await repository.Update(workShop);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity workShop)
        {
            await repository.Update(workShop);
            return CreatedAtAction("Get", new { id = workShop.Id }, workShop);
        }
    }
}
