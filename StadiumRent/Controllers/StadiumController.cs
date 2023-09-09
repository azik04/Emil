using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StadiumRent.BLL.Implementations;
using StadiumRent.BLL.Interfaces;
using StadiumRent.DAL.Interfaces;
using StadiumRent.DAL.Repositories;
using StadiumRent.Domain.Entity;
using StadiumRent.Domain.Enum;

namespace StadiumRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumServices _service;
        public StadiumController( IStadiumServices service) 
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var responce =  _service.GetAll();
            if (responce.StatusCode == StadiumRent.Domain.Enum.StatusCode.OK )
            {
                return Ok(responce.Data);
            }
            return BadRequest(responce.Description);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Stadium model)
        {
            var responce = _service.CreateAsync(model);

            return Ok(responce);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete( int id)
        {
            var responce = _service.DeleteAsync(id);
            return Ok(responce);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id , Stadium model) 
        {
            var responce = _service.UpdateAsync(id , model);
            return Ok(responce);
        }
    }
}
