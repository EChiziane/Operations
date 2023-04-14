using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Driver model)
        {
            try
            {
                var driver = await _driverService.AddDriver(model);
                if (driver is null) return BadRequest("Error Trying to Save User");
                return Ok(driver);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Trying to save User. error{e.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var drivers = await _driverService.GetAllDriversAsync();
                if (drivers is null) return NotFound("Nenhum User Encontrado");
                return Ok(drivers);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {var driver = await _driverService.GetDriverByIdAsync(id);
                if (driver is null) return NotFound("User Type not Found");
                return await _driverService.DeleteDriver(id)
                    ? Ok(driver)
                    : BadRequest("User was deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Trying to delete {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var driver = await _driverService.GetDriverByIdAsync(id);
                if (driver is null) return NotFound("User Type not Found");
                return Ok(driver);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying to found driver. Error {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Driver model)
        {
            try
            {
                var driver = await _driverService.UpdateDriver(id, model);
                if (driver is null) return BadRequest("Error Trying To Update");
                return Ok(driver);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error Trying to update driver. Error {e.Message}");
            }
        }
    }
}