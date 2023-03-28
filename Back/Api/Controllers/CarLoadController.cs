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
    public class CarLoadController:ControllerBase
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
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar carLoads. Erro: {ex.Message}");
            }
        }

    }
}

