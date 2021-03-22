using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Shared
{
    public class MaestrosCls
    {
        public int MaestroId { get; set; }
        public string Nombre { get; set; }

        public virtual List<CursoCls> CursosOnLineMaestros { get; set; }
        public virtual List<CursoCls> CursosPresencialMaestros { get; set; }
    }
}
