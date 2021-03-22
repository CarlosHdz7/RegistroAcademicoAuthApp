using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Server.Models
{
    public class DetRegistroAcademico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetRegistroIdAcad { get; set; }

        public int? CursosId { get; set; }
        public int? EncRegistroAcademicoId { get; set; }
        public virtual Cursos CursoEstudiante { get; set; }
        public virtual EncRegistroAcademico EncRegroAcademicoEnc { get; set; }
    }
}
