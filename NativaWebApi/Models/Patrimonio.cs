using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativaWebApi.Models
{
    public class Patrimonio
    {
        public int numeroTombo { get; set; }
        public int marcaId { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public Marca marca { get; set; }

        public class Mapeamento {
            public Mapeamento(EntityTypeBuilder<Patrimonio> mapeamentoNoticia)
            {                
                mapeamentoNoticia.HasKey(x => x.numeroTombo);
                mapeamentoNoticia.HasOne(x => x.marca);
                
            }
        }
    }
}
