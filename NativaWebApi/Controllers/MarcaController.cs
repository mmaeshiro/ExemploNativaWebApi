using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NativaWebApi.Models;
using NativaWebApi.Services;

namespace NativaWebApi.Controllers
{
    [Route("api/Marca")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly MarcaService _marcaService;
        public MarcaController(MarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        [Route("ObterTodos")]
        [Authorize(Roles = "admin,gerente,funcionario")]
        public IActionResult ObterTodosMarca()
        {
            var resultado = _marcaService.ObterTodos();

            return Ok(resultado);
        }

        [HttpPost]
        [Route("Adicionar")]
        [Authorize(Roles = "admin,gerente")]
        public IActionResult AdicionarMarca([FromBody] Marca _marca)
        {
            var resultado = _marcaService.AdicionarMarca(_marca);

            if (resultado.ToLower() == "sucesso")
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }

        [HttpPut]
        [Route("Editar")]
        [Authorize(Roles = "admin,gerente")]
        public IActionResult EditarMarca([FromBody] Marca _marca)
        {
            var resultado = _marcaService.EditarMarca(_marca);

            if (resultado.ToLower() == "sucesso")
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }
      
    }
}