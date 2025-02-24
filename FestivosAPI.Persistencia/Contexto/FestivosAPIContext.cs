using Microsoft.EntityFrameworkCore;
using FestivosAPI.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivosAPI.Persistencia.Contexto
{
    public class FestivosAPIContext : DbContext
    {
        public FestivosAPIContext(DbContextOptions<FestivosAPIContext> options) : base(options)
        {

        }

        public DbSet<Festivo> Festivos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }

        void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}

