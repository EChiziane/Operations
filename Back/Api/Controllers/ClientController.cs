using System;
using System.Threading.Tasks;
using Application;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Client model)
        {
            try
            {
                var client = await _clientService.AddClient(model);
                if (client is null) return BadRequest("Error Trying to Save User");
                return Ok(client);
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
                var clients = await _clientService.GetAllClientsAsync();
                if (clients is null) return NotFound("Nenhum User Encontrado");
                return Ok(clients);
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
                return await _clientService.DeleteClient(id)
                    ? Ok("Deletado")
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
                var client = await _clientService.GetClientByIdAsync(id);
                if (client is null) return NotFound("User Type not Found");
                return Ok(client);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying to found client. Error {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Client model)
        {
            try
            {
                var client = await _clientService.UpdateClient(id, model);
                if (client is null) return BadRequest("Error Trying To Update");
                return Ok(client);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error Trying to update client. Error {e.Message}");
            }
        }
    }
}