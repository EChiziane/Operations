using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/carloads")]
    public class CarLoadController : ControllerBase
    {
        private readonly ICarLoadService _carLoadService;

        public CarLoadController(ICarLoadService carLoadService)
        {
            _carLoadService = carLoadService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CarLoad model)
        {
            try
            {
                var carLoad = await _carLoadService.AddCarLoad(model);
                if (carLoad == null) return BadRequest("Erro ao tentar adicionar carLoad.");

                return Ok(carLoad);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar carLoads. Erro: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var carLoads = await _carLoadService.GetAllCarLoadsAsync();
                if (carLoads is null) return NotFound("Nenhum CarLoad Encontrado");
                return Ok(carLoads);
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
            {
                var carload = await _carLoadService.GetCarLoadByIdAsync(id,
                    false,
                    false,
                    false);
                return await _carLoadService.DeleteCarLoad(id)
                    ? Ok("Deleted")
                    : BadRequest("CarLoad deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Trying to delete {e.Message}"); 
            }
        }
    }
}