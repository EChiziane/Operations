﻿using System;
using System.Threading.Tasks;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialTypeController:ControllerBase
    {
        private readonly IMaterialTypeService _materialTypeService;


        public MaterialTypeController(IMaterialTypeService materialTypeService )
        {
            _materialTypeService = materialTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMaterialType()
        {
            try
            {
                var materialTypes = await _materialTypeService.GetAllMaterialTypesAsync();
                if (materialTypes is null) return NotFound("Nenhum Material Type Encontrado");
                return Ok(materialTypes);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao Tentar Carregar Material Types. Erro: {e.Message}");
            }
        }
        
    }
}