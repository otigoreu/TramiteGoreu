
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using TramiteGoreu.Dto.Request;
using TramiteGoreu.Dto.Response;
using TramiteGoreu.Entities;
using TramiteGoreu.Repositories;
using TramiteGoreu.Services.Interface;

namespace TramiteGoreu.Api.Controllers
{
    [ApiController]
    [Route("api/persons")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService service;

        public PersonsController(IPersonService service)
        {
            this.service = service;
        }

        [HttpGet("nombre")]
        public async Task<IActionResult> Get(string? nombres)
        {
            var response=await service.GetAsync(nombres);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id) 
        {
            var response = await service.GetAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PersonRequestDto personRequestDto) 
        {
            var response = await service.AddAsync(personRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id,PersonRequestDto personRequestDto) 
        {
            var response = await service.UpdateAsync(id,personRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var response = await service.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id)
        {
            var response = await service.FinalizedAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
