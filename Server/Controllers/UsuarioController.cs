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
  
    public class UsuarioController : Controller
    {
        [HttpPost]
        [Route("api/Usuario/login")]
        public int login([FromBody] UsuarioCls oUsuario)
        {
            int rpta = 0;
            try
            {
                using (RegistroAcademicoContext cn = new RegistroAcademicoContext())
                {
                    string clave = oUsuario.pass;
                    /* SHA256Managed sha = new SHA256Managed();
                     byte[] buffer = Encoding.Default.GetBytes(clave);
                     byte[] dataCifrada = sha.ComputeHash(buffer);
                     string dataCifradaCadena = BitConverter.ToString(dataCifrada);*/


                    int nveces = cn.Usuarios.Where(p => p.nombre == oUsuario.nombre && p.pass == oUsuario.pass).Count();
                    if (nveces == 0)
                    {
                        rpta = 0;
                    }
                    else
                    {
                        rpta = cn.Usuarios.Where(p => p.nombre == oUsuario.nombre && p.pass == oUsuario.pass).First().idUsuario;
                    }
                }
            }
            catch (Exception)
            {

                rpta = 0;
            }
            return rpta;
        }

        [HttpPost]
        [Route("api/Usuario/Guardar")]
        public async Task<ActionResult<int>> Guardar(UsuarioCls usuarioCls)
        {

            int rpta = 0;
            try
            {

                using (RegistroAcademicoContext db = new RegistroAcademicoContext())
                {
                    Usuario oUsuario = new Usuario();
                    if (usuarioCls.idUsuario == 0)
                    {
                        oUsuario.idUsuario = usuarioCls.idUsuario;
                        oUsuario.nombre = usuarioCls.nombre;
                        oUsuario.pass = usuarioCls.pass;
                        db.Usuarios.Add(oUsuario);
                    }
                    else
                    {
                        Usuario u = db.Usuarios.Where(u => u.idUsuario == usuarioCls.idUsuario).FirstOrDefault();
                        u.nombre = usuarioCls.nombre;
                        u.pass = usuarioCls.pass;
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
        [Route("api/Usuario/EliminarUsuario/{data?}")]
        public int eliminarUsuario(string data)
        {
            int rpta = 0;
            try
            {
                using (RegistroAcademicoContext db = new RegistroAcademicoContext())
                {
                    int idUsuario = int.Parse(data);
                    Usuario usuario = db.Usuarios.Where(u => u.idUsuario == idUsuario).First();
                    db.Attach(usuario);
                    db.Remove(usuario);
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
        [Route("api/Usuario/Filtrar/{data?}")]
        public List<Usuario> Filtrar(string data)
        {
            List<Usuario> lista = new List<Usuario>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                if (data == null)
                {
                    lista = (from gd in db.Usuarios
                             select new Usuario
                             {
                                 idUsuario = gd.idUsuario,
                                 nombre = gd.nombre,
                                 pass = gd.pass
                             }).ToList();
                }

                else
                {
                    lista = (from g in db.Usuarios
                             where g.idUsuario.ToString().Contains(data) || g.nombre.Contains(data) ||
                                   g.pass.Contains(data)
                             select new Usuario
                             {
                                 idUsuario = g.idUsuario,
                                 nombre = g.nombre,
                                 pass = g.pass
                             }).ToList();

                }
            }
            return lista;

        }

        [HttpGet]
        [Route("api/Usuario/Get")]
        public List<UsuarioCls> Get()
        {
            List<UsuarioCls> lista = new List<UsuarioCls>();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                lista = (from u in db.Usuarios
                         select new UsuarioCls
                         {                             
                                 idUsuario = u.idUsuario,
                                 nombre = u.nombre,
                                 pass =u.pass
                           
                         }).ToList();
            }
            return lista;

        }

        [HttpGet]
        [Route("api/Usuario/obtenerUsuario/{idUsuario}")]
        public UsuarioCls obtenerUsuario(int idUsuario)
        {
            UsuarioCls usuarioCls = new UsuarioCls();
            using (RegistroAcademicoContext db = new RegistroAcademicoContext())
            {
                usuarioCls = (from usuario in db.Usuarios
                           where usuario.idUsuario == idUsuario
                           select new UsuarioCls
                           {
                               idUsuario = usuario.idUsuario,
                               nombre = usuario.nombre,
                               pass = usuario.pass

                           }).First();

            }
            return usuarioCls;
        }

    }
}
