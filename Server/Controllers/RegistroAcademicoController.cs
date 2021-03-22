using Microsoft.AspNetCore.Mvc;
using RegistroAcademicoApp.Client.Repositorio;
using RegistroAcademicoApp.Server.Models;
using RegistroAcademicoApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;


namespace RegistroAcademicoApp.Server.Controllers
{
    [ApiController]
    public class RegistroAcademicoController : Controller
    {
        [HttpPost]
        [Route("api/RegistroAcad/Guardar/{data?}")]
        public ActionResult<int> Guardar(EncRegistroAcademico reg)
        {


            EncRegistroAcademico ec = null;

            using (TransactionScope transacion = new TransactionScope())
            {
                using (var db = new RegistroAcademicoContext())
                {
                    //1. Verificamos si hay cupo
                    Cursos cursoSelected = reg.DetRegistroAcademicosDet.First().CursoEstudiante;
                    var cupo = db.CuposCurso.Where(cp => cp.CursosCupo.CursoId == cursoSelected.CursoId && cp.Year == DateTime.Now.Year).First();

                    var reservas = db.DetRegistroAcademico.Where(c => c.CursoEstudiante.CursoId == cursoSelected.CursoId).Count();
                    int existencia = cupo.Cupo - int.Parse(reservas.ToString());


                    if (existencia > 0)
                    {
                        //2. Guardamos Estudiante
                        db.Estudiante.Attach(reg.EstudianteReg);
                        ec = new EncRegistroAcademico()
                        {
                            Fecha = DateTime.Now,
                            EstudianteReg = reg.EstudianteReg

                        };
                        ec.DetRegistroAcademicosDet = new List<DetRegistroAcademico>();
                        DetRegistroAcademico dt = new DetRegistroAcademico();
                        foreach (var item in reg.DetRegistroAcademicosDet)
                        {
                            item.CursoEstudiante.CursoId = item.CursoEstudiante.CursoId;
                            db.Cursos.Attach(item.CursoEstudiante);
                            dt.CursoEstudiante = item.CursoEstudiante;
                            dt.CursosId = item.CursosId;
                            dt.EncRegistroAcademicoId = ec.EstudianteId;
                            dt.EncRegroAcademicoEnc = ec;
                            ec.DetRegId = dt.DetRegistroIdAcad;
                            ec.DetRegistroAcademicosDet.Add(dt);
                        }

                        db.EncRegistroAcademcico.Add(ec);
                         db.SaveChanges();

                        //3. Descontamos de cupo
                        var cupoUpdate = db.CuposCurso.Where(c => c.CursosId == cupo.CursosId).First();
                        cupoUpdate.Cupo -= 1;
                         db.SaveChanges();
                        transacion.Complete();
                        return 0;
                    }
                    else
                    {
                        return  View("1");

                    }
                }
            }





        }



    }
}
