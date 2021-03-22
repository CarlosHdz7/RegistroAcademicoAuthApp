using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Server.Models
{
    public class Perfil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerfil { get; set; }
        public string OpcionMenu { get; set; }

        public int? UsuarioId { get; set; }

        public virtual Usuario UsuarioPerfil { get; set; }
    }
}
