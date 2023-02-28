using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{ [ApiController]
    [Route("api/[controller]")]
    public class OperationController:ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Operation model)
        {
            try
            {
                var opetration = await _operationService.AddOperations(model);
                if (opetration is null) return BadRequest("Erro ao Adicionar Essa Operacao");
                return Ok(opetration);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao Tentar Adicionar essa Operacao. Erro :{e.Message}");
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var operations = await _operationService.GetAllOperationAsync(true);
                if (operations is null) return NotFound("Nenhuma Operacao Encontrada");
                return Ok(operations);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar capturar as Operacoes. Erro:{e.Message}");
            }
        }
    }
}