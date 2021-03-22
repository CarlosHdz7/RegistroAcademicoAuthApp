using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Shared
{
    public class CuposCursosCls
    {
        
        public int IdCuposCurso { get; set; }
        
        public int Cupo { get; set; }
        public int Year { get; set; }

        public int? CursosId { get; set; }
        public CursoCls CursosCupo { get; set; }
    }
}
