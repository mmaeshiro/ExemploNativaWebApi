using NativaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativaWebApi.Services
{
    public class MarcaService
    {
        private readonly DbContexto _dbContexto;
        public MarcaService(DbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public List<Marca> ObterTodos()
        {
            try
            {
                var resultado = _dbContexto.Marca.ToList();
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string AdicionarMarca(Marca _marca)
        {
            try
            {
                var marcaDb = _dbContexto.Marca.Where(x => x.nome.ToLower() == _marca.nome.ToLower()).FirstOrDefault();
                var retorno = string.Empty;

                if (marcaDb == null)
                {

                    _dbContexto.Marca.Add(_marca);
                    _dbContexto.SaveChanges();
                    retorno = "Sucesso";

                }

                if (marcaDb != null)
                    retorno = "Já existe essa marca cadastrada";


                return retorno;
            }
            catch (Exception)
            {
                return "Ocorreu uma falhar ao cadastrada marca.";
            }

        }

        public string EditarMarca(Marca _marca)
        {
            try
            {
                var  VerificaExiste = _dbContexto.Marca.Where(x => x.nome.ToLower() == _marca.nome.ToLower()).FirstOrDefault();

                var retorno = string.Empty;

                if (VerificaExiste == null )
                {
                    var marcaDb = _dbContexto.Marca.Where(x => x.marcaId == _marca.marcaId).FirstOrDefault();
                    marcaDb.marcaId = _marca.marcaId;
                    marcaDb.nome = _marca.nome;

                    _dbContexto.SaveChanges();

                    retorno = "Sucesso";

                }

                if (VerificaExiste != null)
                    retorno = "Já existe essa marca cadastrada";
            
                return retorno;
            }
            catch (Exception)
            {
                return "Ocorreu uma falhar ao cadastrada marca."; ;
            }

        }       

    }
}
