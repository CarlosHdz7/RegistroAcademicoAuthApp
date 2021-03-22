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
    public class PerfilController : Controller
    {
        [HttpGet]
        [Route("api/Perfil/obtenerPerfil/{idPerfil}")]
        public PerfilCls obtenerPerfil(int idPerfil)
        {
            PerfilCls clteCls = new PerfilCls();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                clteCls = (from perfil in db.Perfiles
                           where perfil.IdPerfil == idPerfil
                           select new PerfilCls
                           {
                               IdPerfil = perfil.IdPerfil,
                               OpcionMenu = perfil.OpcionMenu,
                               UsuarioPerfil = new UsuarioCls()
                               {
                                   idUsuario= perfil.UsuarioPerfil.idUsuario,
                                   nombre= perfil.UsuarioPerfil.nombre,
                                   pass= perfil.UsuarioPerfil.pass
                               }

                           }).First();

            }
            return clteCls;
        }

        [HttpPost]
        [Route("api/Perfil/Guardar")]
        public async Task<ActionResult<int>> Guardar(PerfilCls pefilCls)
        {

            int rpta = 0;
            try
            {

                using (RegistroAcademicoContext db = new RegistroAcademicoContext())
                {
                    Perfil oPerfil = new Perfil();
                    if (pefilCls.IdPerfil == 0)
                    {
                        oPerfil.IdPerfil = pefilCls.IdPerfil;
                        oPerfil.OpcionMenu = pefilCls.OpcionMenu;
                        oPerfil.UsuarioPerfil = new Usuario()
                        {
                            idUsuario = pefilCls.UsuarioPerfil.idUsuario,
                            nombre = pefilCls.UsuarioPerfil.nombre,
                            pass = pefilCls.UsuarioPerfil.pass
                        };
                        db.Usuarios.Attach(oPerfil.UsuarioPerfil);
                        db.Perfiles.Add(oPerfil);
                    }
                    else
                    {
                        Perfil p = db.Perfiles.Where(g => g.IdPerfil == pefilCls.IdPerfil).FirstOrDefault();
                        p.OpcionMenu = pefilCls.OpcionMenu;
                        p.UsuarioPerfil = new Usuario()
                        {
                            idUsuario = pefilCls.UsuarioPerfil.idUsuario,
                            nombre = pefilCls.UsuarioPerfil.nombre,
                            pass = pefilCls.UsuarioPerfil.pass
                        };
                    }
                    await db.SaveChangesAsync();
                    rpta = 1;
                }


            }
            catch (Exception)
            {
                rpta = 0;
            }
            return rpta;
        }

        [HttpGet]
        [Route("api/Perfil/EliminarPerfil/{data?}")]
        public int eliminarPerfil(string data)
        {
            int rpta = 0;
            try
            {
                using (RegistroAcademicoContext db = new RegistroAcademicoContext())
                {
                    int idPerfil = int.Parse(data);
                    Perfil perfil = db.Perfiles.Where(p => p.IdPerfil == idPerfil).First();
                    db.Attach(perfil);
                    db.Remove(perfil);
                    db.SaveChanges();
                    rpta = 1;
                }
            }
            catch (Exception)
            {

                rpta = 0;
            }
            return rpta;
        }

        [HttpGet]
        [Route("api/Perfil/Filtrar/{data?}")]
        public List<PerfilCls> Filtrar(string data)
        {
            List<PerfilCls> lista = new List<PerfilCls>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                if (data == null)
                {
                    lista = (from p in db.Perfiles
                             select new PerfilCls
                             {
                                 IdPerfil = p.IdPerfil,
                                 OpcionMenu = p.OpcionMenu,
                                 UsuarioPerfil = new UsuarioCls()
                                 {
                                     idUsuario = p.UsuarioPerfil.idUsuario,
                                     nombre = p.UsuarioPerfil.nombre
                                 }
                             }).ToList();
                }

                else
                {
                    lista = (from p in db.Perfiles
                             where p.IdPerfil.ToString().Contains(data) || p.OpcionMenu.Contains(data) 
                             select new PerfilCls
                             {
                                 IdPerfil = p.IdPerfil,
                                 OpcionMenu = p.OpcionMenu,
                                 UsuarioPerfil = new UsuarioCls()
                                 {
                                     idUsuario = p.UsuarioPerfil.idUsuario,
                                     nombre = p.UsuarioPerfil.nombre
                                 }
                             }).ToList();

                }
            }
            return lista;

        }

        [HttpGet]
        [Route("api/Perfil/Get")]
        public List<PerfilCls> Get()
        {
            List<PerfilCls> lista = new List<PerfilCls>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                lista = (from p in db.Perfiles
                         select new PerfilCls
                         {
                             IdPerfil = p.IdPerfil,
                              OpcionMenu = p.OpcionMenu,
                             UsuarioPerfil = new UsuarioCls()
                             {
                                 idUsuario= p.UsuarioPerfil.idUsuario,
                                 nombre= p.UsuarioPerfil.nombre
                             }
                         }).ToList();
            }
            return lista;

        }

    }
}
