using System;
using System.Collections.Generic;

namespace RegistroAcademicoApp.Server.Models
{
    public partial class Facultad
    {
        public Facultad()
        {
            Estudiante = new HashSet<Estudiante>();
        }

        public int FacultadId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Estudiante> Estudiante { get; set; }
    }
}
