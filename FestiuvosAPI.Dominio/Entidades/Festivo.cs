using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivosAPI.Dominio.Entidades
{
    [Table("Festivo")]
    public class Festivo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nombre"), StringLength(100), NotNull]
        public required string Nombre { get; set; }

        [Column("Dia"), NotNull]
        public int Dia { get; set; }

        [Column("Mes"), NotNull]
        public int Mes { get; set; }

        [Column("DiaPascua"), NotNull]
        public int DiaPascua { get; set; }

        [Column("TipoId"), NotNull]
        public int TipoId { get; set; }

        public Tipo TipoFestivo { get; set; } 

    }
}
