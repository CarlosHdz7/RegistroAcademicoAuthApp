using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAcademicoApp.Shared
{
    public class PerfilCls
    {
        public int IdPerfil { get; set; }
        public string OpcionMenu { get; set; }

        public int? UsuarioId { get; set; }

        public virtual UsuarioCls UsuarioPerfil { get; set; }
    }
}
