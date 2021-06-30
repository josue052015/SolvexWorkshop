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
    [Route("WorkShop")]
    public class WorkShopController : Controller
    {
        private readonly IRepository<WorkShop> repository;

        public WorkShopController(IRepository<WorkShop> repository)
        {
            this.repository = repository;
        }
       
        [HttpGet]
        public  IActionResult Get()
        {
            return Ok();
        }
    }
}
