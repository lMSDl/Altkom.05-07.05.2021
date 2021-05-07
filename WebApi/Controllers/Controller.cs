using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class Controller<T> : ControllerBase where T : Entity
    {
        protected IService<T> service;

        public Controller(IService<T> service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await service.ReadAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.ReadAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(T entity)
        {
            var id = await service.CreateAsync(entity);
            return Created($"{Request.Path}/{id}", id);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, T entity)
        {
            var result = await service.ReadAsync(id);
            if (result == null)
                return NotFound();

            await service.UpdateAsync(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.ReadAsync(id);
            if (result == null)
                return NotFound();

            await service.DeleteAsync(id);
            return NoContent();
        }
    }
}
