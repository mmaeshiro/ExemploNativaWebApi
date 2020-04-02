using NativaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativaWebApi.Services
{
    public class UsuarioService
    {
        private readonly DbContexto _dbContexto;
        public UsuarioService(DbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public object Autenticar(Usuario _usuario)
        {
            try
            {
                var usuarioDB = _dbContexto.Usuario.Where(x => x.email == _usuario.email && x.senha == _usuario.senha).FirstOrDefault();             

                if (usuarioDB == null)
                    return new { message = "Usuário ou senha inválidos" };

                var retornoToken = TokenService.GenerateToken(usuarioDB);
                usuarioDB.senha = string.Empty;
                return new
                {
                    usuario = usuarioDB,
                    token = retornoToken
                };
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> ObterTodos()
        {
            try
            {
                var resultado = _dbContexto.Usuario.ToList();
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AdicionarUsuario(Usuario _usuario)
        {
            try
            {
                var usuarioDb = _dbContexto.Usuario.Where(x => x.email.ToLower() == _usuario.email.ToLower()).FirstOrDefault();
                var retorno = string.Empty;

                if (usuarioDb == null)
                {

                    _dbContexto.Usuario.Add(_usuario);
                    _dbContexto.SaveChanges();
                    retorno = "Sucesso";

                }

                if (usuarioDb != null)
                    retorno = "Já existe essa e-mail cadastrado";


                return retorno;

            }
            catch (Exception)
            {
                return "Ocorreu uma falhar ao cadastrada usuário.";
            }

        }

        public string EditarUsuario(Usuario _usuario)
        {

            try
            {
                var VerificaExiste = _dbContexto.Usuario.Where(x => x.email.ToLower() == _usuario.email.ToLower()).FirstOrDefault();

                var retorno = string.Empty;

                if (VerificaExiste == null)
                {
                    var usuarioDb = _dbContexto.Usuario.Where(x => x.usuarioId == _usuario.usuarioId).FirstOrDefault();
                    usuarioDb.usuarioId = _usuario.usuarioId;
                    usuarioDb.nome = _usuario.nome;
                    usuarioDb.email = _usuario.email;
                    usuarioDb.senha = _usuario.senha;

                    _dbContexto.SaveChanges();

                    retorno = "Sucesso";

                }

                if (VerificaExiste != null)
                    retorno = "Já existe essa e-mail cadastrado";

                return retorno;
            }
            catch (Exception)
            {
                return "Ocorreu uma falhar ao cadastrada usuário."; ;
            }

        }

        public bool ExcluirUsuario(int usuarioId)
        {
            try
            {
                var usuarioDb = _dbContexto.Usuario.Where(x => x.usuarioId == usuarioId).FirstOrDefault();

                _dbContexto.Usuario.Remove(usuarioDb);

                _dbContexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}
