using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Server.Models
{
    public class CuposCursos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCuposCurso { get; set; }

        [DataType(DataType.Currency)]
        public int Cupo { get; set; }
        public int Year { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int? CursosId { get; set; }
        public Cursos CursosCupo { get; set; }
    }
}
