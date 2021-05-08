using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLayerProject.Core.Models;
using NLayerProject.Core.Service;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _presonService;

        public PersonsController(IService<Person> presonService)
        {
            _presonService = presonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _presonService.GetAllAsync();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newperson = await _presonService.AddAsync(person);

            return Ok(newperson);
        }
    }
}
