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
    public class IdentityCardController : ControllerBase
    {
        private readonly IIdentityCardService _identityCardService;

        public IdentityCardController(IIdentityCardService identityCardService)
        {
            _identityCardService = identityCardService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var identityCards = await _identityCardService.GetAllIdentityCardAsync();
                if (identityCards is null) return NotFound("Nenhum IdentityCard Encontrado");
                return Ok(identityCards);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {e.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, IdentityCard model)
        {
            try
            {
                var identityCard = await _identityCardService.UpdateIdentityCard(id, model);
                if (identityCard is null) return BadRequest("Error Trying To Update");
                return Ok(identityCard);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error Trying to update identityCard. Erro {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var identityCard = await _identityCardService.GetIdentityCardByIdAsync(id);
                if (identityCard is null) return NotFound("Operation Type not Found");
                return Ok(identityCard);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying to found identityCard. Error {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(IdentityCard model)
        {
            try
            {
                var identityCard = await _identityCardService.AddIdentityCard(model);
                if (identityCard == null) return BadRequest("Erro ao Tentar Salvar Operation Type");
                return Ok(identityCard);
            }
            catch (Exception e)
            {
                return StatusCode
                (StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar IdentityCard. eEro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _identityCardService.Delete(id)
                    ? Ok("Deletado")
                    : BadRequest("IdentityCard was deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Trying to delete {e.Message}");
            }
        }
    }
}