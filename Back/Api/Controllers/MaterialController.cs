using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contratos;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _materialService;
        private readonly IGeralPersist _geralPersist;

        public MaterialController(IMaterialService materialService, IGeralPersist geralPersist)
        {
            _materialService = materialService;
            _geralPersist = geralPersist;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var materiais = await _materialService.GetAllMaterialsAsync(true);
                if (materiais == null) return NotFound("Nenhum evento encontrado.");

                return Ok(materiais);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar materiais. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _materialService.GetMaterialByIdAsync(id, true);
                if (evento == null) return NotFound("Material por Id não encontrado.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar materiais. Erro: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Material model)
        {
            try
            {
                var evento = await _materialService.AddMaterial(model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar materiais. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Material model)
        {
            try
            {
                var evento = await _materialService.UpdateMaterial(id, model);
                if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar materiais. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {var material = await _materialService.GetMaterialByIdAsync(id);
                if (material is null) return NotFound("Material  Not Found");
                return await _materialService.DeleteMaterial(id) ? Ok(material) : BadRequest("Material não deletado");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar materiais. Erro: {ex.Message}");
            }
        }
    }
}