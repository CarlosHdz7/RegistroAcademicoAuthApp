using System;
using System.Collections.Generic;

namespace RegistroAcademicoApp.Server.Models
{
    public partial class Maestros
    {
        public Maestros()
        {
            CursosOnLineMaestros = new HashSet<Cursos>();
            CursosPresencialMaestros = new HashSet<Cursos>();
        }

        public int MaestroId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cursos> CursosOnLineMaestros { get; set; }
        public virtual ICollection<Cursos> CursosPresencialMaestros { get; set; }
    }
}
