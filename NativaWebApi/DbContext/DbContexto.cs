using Microsoft.EntityFrameworkCore;
using NativaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativaWebApi
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Patrimonio> Patrimonio { get;set;}
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            new Patrimonio.Mapeamento(modelBuilder.Entity<Patrimonio>());
            new Marca.Mapeamento(modelBuilder.Entity<Marca>());
            new Usuario.Mapeamento(modelBuilder.Entity<Usuario>());
        }
    }
}
