using Microsoft.AspNetCore.Mvc;
using RegistroAcademicoApp.Server.Models;
using RegistroAcademicoApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Server.Controllers
{
    [ApiController]
    public class EstudianteController : Controller
    {
        [HttpGet]
        [Route("api/Estudiante/GetEstudiantes")]
        public List<EstudiantesCls> GetEstudiantes()
        {
            List<EstudiantesCls> lst = new List<EstudiantesCls>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                lst = (from estudiante in db.Estudiante
                       select new EstudiantesCls()
                       {
                           IdEstudiante = estudiante.IdEstudiante,
                           Nombre = estudiante.Nombre
                       }).ToList();

            }
            return lst;
        }
    }
}
