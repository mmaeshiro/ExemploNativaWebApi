using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativaWebApi.Models
{
    public class Usuario
    {
        public int usuarioId { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string role { get; set; }

        public class Mapeamento
        {
            public Mapeamento(EntityTypeBuilder<Usuario> mapeamentoNoticia)
            {
                mapeamentoNoticia.HasKey(x => x.usuarioId);               
            }
        }
    }
}
