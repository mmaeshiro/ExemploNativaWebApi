using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativaWebApi.Models
{
    public class Marca
    {
        public int marcaId { get; set; }
        public string nome { get; set; }

        public class Mapeamento
        {
            public Mapeamento(EntityTypeBuilder<Marca> mapeamentoNoticia)
            {
                mapeamentoNoticia.HasKey(x => x.marcaId);
            }
        }
    }   
}
