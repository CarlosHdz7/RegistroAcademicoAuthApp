using System;
using System.Collections.Generic;

namespace RegistroAcademicoApp.Server.Models
{
    public partial class Grado
    {
        public Grado()
        {
            Estudiante = new HashSet<Estudiante>();
        }

        public int GradoId { get; set; }
        public string GradoNombre { get; set; }
        public string Seccion { get; set; }

        public virtual ICollection<Estudiante> Estudiante { get; set; }
    }
}
