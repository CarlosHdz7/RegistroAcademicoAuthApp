using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Shared
{
    public class DetRegistroAcademicoCls
    {
        public int DetRegistroIdAcad { get; set; }

        public int? CursosId { get; set; }
        public int? EncRegistroAcademicoId { get; set; }
        public virtual CursoCls CursoEstudiante { get; set; }
        public virtual EncRegistroAcademicoCls EncRegroAcademicoEnc { get; set; }
    }
}
