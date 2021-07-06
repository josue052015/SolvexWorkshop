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
  
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        //{
        //    return await repository.GetAll();
        //}

      
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var movie = await repository.GetById(id);
            if (movie == null) return NotFound();
            
            return movie;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity movie)
        {
            if (id != movie.Id) return BadRequest();
            
            await repository.Update(movie);
            return NoContent();
        }

     
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity movie)
        {
            await repository.Create(movie);
            return CreatedAtAction("Get", new { id = movie.Id }, movie);
        }

       

    }
}
