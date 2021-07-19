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
    public class WorkShopMembersController :  BaseController<WorkShopMember, MembersRepository>
    {
        private readonly MembersRepository _repository;

        public WorkShopMembersController(MembersRepository repository) : base(repository)
        {
            this._repository = repository;
        }
        [HttpGet]
        public async Task<ActionResult<List<WorkShopMember>>> Get()
        {
            var workshopMemberResult = _repository.GetAll();

            return await workshopMemberResult;
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {

            var workShopMember = await _repository.Delete(id);
            if (workShopMember == null) return NotFound();

            return NoContent();
        }
    }
}
