using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Shared
{
    public class UsuarioCls
    {
        public int idUsuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar el nombre del usuario")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar la contraseña del usuario")]
        [MinLength(8,ErrorMessage ="Minimo de caracteres es 8")]
        public string pass { get; set; }
    }
}
