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
        public DbSet<Festivo> Festivos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public FestivosAPIContext(DbContextOptions<FestivosAPIContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Modelo Festivo

            builder.Entity<Festivo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            // Modelo Festivo - Foreign Key

            builder.Entity<Festivo>()
                .HasOne(e => e.TipoFestivo)
                .WithMany()
                .HasForeignKey(e => e.TipoId);

            // Modelo Tipo

            builder.Entity<Tipo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Descripcion).IsUnique();
            });            
        }
    }
}

