using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NativaWebApi.Models;
using NativaWebApi.Services;

namespace NativaWebApi.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Autenticar([FromBody]Usuario _usuario)
        {

            var retorno = _usuarioService.Autenticar(_usuario);
         
            if (Settings.IsPropertyExist(retorno, "message"))
                return NotFound(retorno.GetType().GetProperty("message").GetValue(retorno, null).ToString());
            else
                return Ok(retorno);

        }      

        [HttpGet]
        [Route("ObterTodos")]
        [Authorize(Roles ="admin,gerente")]
        public IActionResult ObterTodosUsuario()
        {
            var resultado = _usuarioService.ObterTodos();

            return Ok(resultado);
        }

        [HttpPost]
        [Route("Adicionar")]
        [Authorize(Roles = "admin,gerente")]
        public IActionResult AdicionarUsuario([FromBody] Usuario _usuario)
        {
            var resultado = _usuarioService.AdicionarUsuario(_usuario);

            if (resultado.ToLower() == "sucesso")
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }

        [HttpPut]
        [Route("Editar")]
        [Authorize(Roles = "admin,gerente")]
        public IActionResult EditarUsuario([FromBody]  Usuario _usuario)
        {
            var resultado = _usuarioService.EditarUsuario(_usuario);

            if (resultado.ToLower() == "sucesso")
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult ExcluirUsuario(int id)
        {
            var resultado = _usuarioService.ExcluirUsuario(id);

            if (resultado)
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }

    }
}