using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroAcademicoApp.Shared;
using RegistroAcademicoApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistroAcademicoApp.Server.Controllers
{
    [ApiController]
    
    public class MaestroController : Controller
    {
        [HttpGet]
        [Route("api/Maestro/GetMaestros")]
        public List<Maestros> GetMaestros()
        {
            List<Maestros> lst = new List<Maestros>();
            using(var db = new RegistroAcademicoContext())
            {
                
                lst = (from maestro in db.Maestros
                             select new Maestros()
                             {
                                 MaestroId=maestro.MaestroId,
                                 Nombre = maestro.Nombre,
                                 //CursosPresencialMaestros=maestro.CursosPresencialMaestros
                                  CursosPresencialMaestros=(from m in maestro.CursosPresencialMaestros
                                                            select new Cursos
                                                            {
                                                                CursoId=m.CursoId,
                                                                 NombreCurso=m.NombreCurso,
                                                                 Descripcion=m.Descripcion,
                                                                 CuposCurso=db.CuposCurso.Where(cup=>cup.CursosId == m.CursoId && cup.Year == DateTime.Now.Year).ToList()
                                                            }).ToList()
                             }).ToList();

            }
            return lst;
        }
    }
}
