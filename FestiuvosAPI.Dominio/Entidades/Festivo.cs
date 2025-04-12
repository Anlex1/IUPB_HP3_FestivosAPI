using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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

        [Column("DiasPascua"), NotNull]
        public int DiaPascua { get; set; }

        [Column("IdTipo"), NotNull]
        public int TipoId { get; set; }

        public Tipo? TipoFestivo { get; set; } 

    }
}
