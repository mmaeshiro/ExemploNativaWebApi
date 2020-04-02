using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NativaWebApi.Models;
using NativaWebApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NativaWebApi.Controllers
{
    [ApiController]
    [Route("api/Patrimonio")]
    public class PatrimonioController : Controller
    {

        private readonly PatrimonioService _patrimonioService;
        public PatrimonioController(PatrimonioService patrimonioService)
        {
            _patrimonioService = patrimonioService;
        }

        [HttpGet]
        [Route("ObterTodos")]
        [Authorize(Roles = "admin,gerente")]
        public IActionResult ObterTodosPatrimonio()
        {
            var resultado = _patrimonioService.ObterTodos();

            return Ok(resultado);
        }

        [HttpPost]
        [Route("Adicionar")]
        [Authorize(Roles = "admin,gerente")]
        public IActionResult AdicionarPatrimonio([FromBody] Patrimonio _patrimonio)
        {
            var resultado = _patrimonioService.AdicionarPatrimonio(_patrimonio);

            if (resultado)
                return Ok(resultado);
            else
                return BadRequest();
        }

        [HttpPut]
        [Route("Editar")]
        [Authorize(Roles = "admin,gerente")]
        public IActionResult EditarPatrimonio([FromBody] Patrimonio _patrimonio)
        {
            var resultado = _patrimonioService.EditarPatrimonio(_patrimonio);

            if (resultado)
                return Ok(resultado);
            else
                return BadRequest();
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult ExcluirPatrimonio(int id)
        {
            var resultado = _patrimonioService.ExcluirPatrimonio(id);

            if (resultado)
                return Ok(resultado);
            else
                return BadRequest();
        }

    }
}
