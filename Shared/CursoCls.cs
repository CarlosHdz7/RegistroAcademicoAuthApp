using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Shared
{
    public class CursoCls
    {
        public int CursoId { get; set; }
        public string NombreCurso { get; set; }
        public string Descripcion { get; set; }
        public int? OnLineMaestrosId { get; set; }
        public int? PresencialMaestrosId { get; set; }
        public int Cupo { get; set; }

        public virtual MaestrosCls OnLineMaestros { get; set; }
        public virtual MaestrosCls PresencialMaestros { get; set; }
        public virtual ICollection<CuposCursosCls> CuposCurso { get; set; }
    }
}
