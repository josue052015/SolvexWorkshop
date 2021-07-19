using GenericApi.Model.Entities;
using GenericApi.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkShopDayController : BaseController<WorkShopDay, WorkShopDayRepository>
    {
        private readonly WorkShopDayRepository _repository;

        public WorkShopDayController(WorkShopDayRepository repository) : base(repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<WorkShopDay>>> Get()
        {
            var workshopDayResult = _repository.GetAll();

            return await workshopDayResult;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var workShopDay = await _repository.Delete(id);
            if (workShopDay == null) return NotFound();

            return NoContent();
        }
    }
}
