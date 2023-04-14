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
    public class OperationTypeController : ControllerBase
    {
        private readonly IOperationTypeService _operationTypeService;

        public OperationTypeController(IOperationTypeService operationTypeService)
        {
            _operationTypeService = operationTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var operationTypes = await _operationTypeService.GetAllOperationTypeAsync();
                if (operationTypes is null) return NotFound("Nenhum OperationType Encontrado");
                return Ok(operationTypes);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {e.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, OperationType model)
        {
            try
            {
                var operationType = await _operationTypeService.UpdateOperationType(id, model);
                if (operationType is null) return BadRequest("Error Trying To Update");
                return Ok(operationType);
            }
            catch (Exception e)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    $"Error Trying to update operationType. Erro {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var operationType = await _operationTypeService.GetOperationTypeByIdAsync(id);
                if (operationType is null) return NotFound("Operation Type not Found");
                return Ok(operationType);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying to found operationType. Error {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(OperationType model)
        {
            try
            {
                var operationType = await _operationTypeService.AddOperationType(model);
                if (operationType == null) return BadRequest("Erro ao Tentar Salvar Operation Type");
                return Ok(operationType);
            }
            catch (Exception e)
            {
                return StatusCode
                (StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar salvar OperationType. eEro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var operationType = await _operationTypeService.GetOperationTypeByIdAsync(id);
                if (operationType is null) return NotFound("Operation Type not Found");
                return await _operationTypeService.Delete(id)
                    ? Ok(operationType)
                    : BadRequest("OperationType was deleted");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error Trying to delete {e.Message}");
            }
        }
    }
}