using GenericApi.Core.BaseModel;
using GenericApi.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
          where TEntity : class, IBaseEntity
          where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }
   
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var movie = await repository.GetById(id);
            if (movie == null) return NotFound();
            
            return movie;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.Id) return BadRequest();
            
            await repository.Update(entity);
            return NoContent();
        }

     
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await repository.Create(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

       

    }
}
