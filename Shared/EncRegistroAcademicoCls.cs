using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Shared
{
    public class EncRegistroAcademicoCls
    {
        public int IdEncRegistroAcad { get; set; }

        public DateTime Fecha { get; set; }
        public int? EstudianteId { get; set; }
        public int? DetRegId { get; set; }

        public virtual EstudiantesCls EstudianteReg { get; set; }
        public virtual ICollection<DetRegistroAcademicoCls> DetRegistroAcademicosDet { get; set; }
    }
}
