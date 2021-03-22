using System;
using System.Collections.Generic;

namespace RegistroAcademicoApp.Server.Models
{
    public partial class DireccionEstudiantes
    {
        public int IdDireccionEstudiante { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public int? EstudianteIdEstudiante { get; set; }

        public virtual Estudiante EstudianteIdEstudianteNavigation { get; set; }
    }
}
