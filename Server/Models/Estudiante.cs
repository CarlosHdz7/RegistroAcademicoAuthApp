using System;
using System.Collections.Generic;

namespace RegistroAcademicoApp.Server.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            DireccionEstudiantes = new HashSet<DireccionEstudiantes>();
        }

        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public DateTime? DoB { get; set; }
        public byte[] Photo { get; set; }
        public decimal Altura { get; set; }
        public float Peso { get; set; }
        public int FacultadRefId { get; set; }
        public int NumeroRegistro { get; set; }
        public byte[] RowVersion { get; set; }
        public int GradoId { get; set; }
        public int? CursosCursoId { get; set; }

        public virtual Cursos CursosCurso { get; set; }
        public virtual Facultad FacultadRef { get; set; }
        public virtual Grado Grado { get; set; }
        public virtual ICollection<DireccionEstudiantes> DireccionEstudiantes { get; set; }
    }
}
