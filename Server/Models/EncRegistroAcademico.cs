using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Server.Models
{
    public class EncRegistroAcademico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEncRegistroAcad { get; set; }

        public DateTime Fecha { get; set; }
        public int? EstudianteId { get; set; }
        public int? DetRegId { get; set; }

        public virtual Estudiante EstudianteReg { get; set; }
        public virtual ICollection<DetRegistroAcademico> DetRegistroAcademicosDet { get; set; }

    }
}
