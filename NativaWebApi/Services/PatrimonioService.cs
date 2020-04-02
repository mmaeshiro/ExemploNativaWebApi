using Microsoft.EntityFrameworkCore;
using NativaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativaWebApi.Services
{
    public class PatrimonioService
    {
        private readonly DbContexto _dbContexto;
        public PatrimonioService( DbContexto dbContexto)
        {
            _dbContexto = dbContexto;
        }

        public List<Patrimonio> ObterTodos()
        {
            try
            {
                var resultado = _dbContexto.Patrimonio.Include(x => x.marca).ToList();
                return resultado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AdicionarPatrimonio(Patrimonio _patrimonio)
        {
            try
            {
                _dbContexto.Patrimonio.Add(_patrimonio);
                _dbContexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public bool EditarPatrimonio(Patrimonio _patrimonio)
        {
            try
            {
                var patrimonioDb = _dbContexto.Patrimonio.Where(x => x.numeroTombo == _patrimonio.numeroTombo).FirstOrDefault();

                patrimonioDb.marcaId = _patrimonio.marcaId;
                patrimonioDb.nome = _patrimonio.nome;
                patrimonioDb.descricao = _patrimonio.descricao;

                _dbContexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool ExcluirPatrimonio(int numeroTombo)
        {
            try
            {
                var patrimonioDb = _dbContexto.Patrimonio.Where(x => x.numeroTombo == numeroTombo).FirstOrDefault();

                _dbContexto.Patrimonio.Remove(patrimonioDb);

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
