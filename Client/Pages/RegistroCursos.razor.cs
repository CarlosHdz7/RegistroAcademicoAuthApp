using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RegistroAcademicoApp.Shared;


namespace RegistroAcademicoApp.Client.Pages
{
    public partial class RegistroCursos
    {
        private int cbxMaestro;
        private string tipoMsg = "",msg="";
        private CursoCls CursoSelected;
        private EstudiantesCls EstudianteSelected;
        public MaestrosCls[] LstMaestros { get; set; } = null;
        public MostrarCursos[] DetalleRegistro { get; set; }
        public List<CursoCls> LstCursos { get; set; } = null;
        public EstudiantesCls[] LstEstudiantes { get; set; }
        MaestrosCls maestroSelected = new MaestrosCls();
        List<MostrarCursos> lstAux = new List<MostrarCursos>();
        public EncRegistroAcademicoCls encRegistroCls { get; set; }


        public void BuscarCursoPorMaestro()
        {
            LstCursos = null;            
            maestroSelected = LstMaestros.Where(c => c.MaestroId == cbxMaestro).First();
            //LstCursos = maestroSelected.CursosPresencialMaestros;
            LstCursos = (from c in maestroSelected.CursosPresencialMaestros
                         select new CursoCls()
                         {
                             CursoId = c.CursoId,
                             Descripcion = c.Descripcion,
                             Cupo = c.CuposCurso.Where(s => s.Year == DateTime.Now.Year).Select(c => c.Cupo).First(),
                             NombreCurso = c.NombreCurso
                         }).ToList() ;
        }

     
        private async Task<IEnumerable<EstudiantesCls>> buscarEstudiante(string seachText)
        {
            if (!seachText.Equals(""))
            {
                return await Task.FromResult(LstEstudiantes.Where(x => x.IdEstudiante.ToString().ToLower().Contains(seachText.ToLower()) || x.Nombre.ToLower().Contains(seachText.ToLower())).ToList());
            }
            else
            {
                return await Task.FromResult(LstEstudiantes);
            }
        }
        private async Task<IEnumerable<CursoCls>> buscarCursos(string seachText)
        {
            if (!seachText.Equals(""))
            {
                return await Task.FromResult(LstCursos.Where(x => x.NombreCurso.ToLower().Contains(seachText.ToLower())).ToList());
            }
            else
            {
                return await Task.FromResult(LstCursos);
            }
        }

        public async Task GuardarDatos()
        {
            encRegistroCls = new EncRegistroAcademicoCls();
            encRegistroCls.DetRegistroAcademicosDet = new List<DetRegistroAcademicoCls>();
            encRegistroCls.EstudianteReg = EstudianteSelected;
            encRegistroCls.DetRegistroAcademicosDet=new List<DetRegistroAcademicoCls>();            
            DetRegistroAcademicoCls dt = new DetRegistroAcademicoCls();            
            dt.CursoEstudiante= CursoSelected;
            dt.CursosId = CursoSelected.CursoId;
            encRegistroCls.DetRegistroAcademicosDet.Add(dt);
                        
            var response = await repositorio.Post("api/RegistroAcad/Guardar", encRegistroCls);
            if (response.Error)
            {
                var body = await response.HttpResponseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                tipoMsg = "alert-danger";
                msg = "No fue posible guardar factura ....";
            }
            else
            {
                tipoMsg = "alert-primary";
                msg = "Se guardo factura con exito ....";
                Console.WriteLine("Guardado exitoso...");
                // Agregamos curso
                lstAux.Add(
                    new MostrarCursos()
                    {
                        Codigo = dt.CursoEstudiante.CursoId,
                        NombreCurso = dt.CursoEstudiante.NombreCurso,
                        Maestro = maestroSelected.Nombre
                    }
                );
                DetalleRegistro = lstAux.ToArray();
                LstCursos = new List<CursoCls>();                
                maestroSelected = null;
               
            }

        }
       


    }
}
