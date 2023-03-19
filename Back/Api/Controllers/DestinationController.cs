using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{[ApiController]
    [Route("api/[controller]")]
    public class DestinationController: ControllerBase
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetDestination()
        {
            try
            {
                var destinations = await _destinationService.GetAllDestinationsAsync();
                if (destinations is null) return NotFound("Nenhum Destination  Encontrado");
                return Ok(destinations);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao Tentar Carregar Destination s. Erro: {e.Message}");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> PostDestination(Destination model)
        {
            try
            {
                var destination = await _destinationService.AddDestination(model);
                if (destination is null) return BadRequest("Erro ao tentar salvar Destination ");
                return Ok(destination);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar Destination . Erro:{e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDestinationById(int id)
        {
            try
            {
                var destination = await _destinationService.GetDestinationByIdAsync(id);
                if (destination is null) return NotFound("Destination  Not Found");
                return Ok(destination);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Trying do Found that operation . Error {e.Message}");
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestination(int id, Destination model)
        {
            try
            {
                var destination = await _destinationService.UpdateDestination(id,model);
                if (destination is null) return NotFound("Destination  Not Found");
                return Ok(destination);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error Trying to update Destination. Erro {e.Message}");
            }  
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            try
            {
                return await _destinationService.DeleteDestination(id)
                    ? Ok("Deletado")
                    : BadRequest("Destination was deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Trying to delete {e.Message}");
            }
        }
    }
}