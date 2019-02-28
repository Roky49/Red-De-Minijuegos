using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace RedSocialMinijuegos.Models
{
    public class UsuarioPrincipal: IPrincipal
    {

        public string Email { get; set; }
        public byte[] PassWord { get; set; }
        public Nullable<int> Gemas { get; set; }
        public Nullable<int> Puntiacion { get; set; }
        public Nullable<System.DateTime> UltimaConexion { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; }
        public string Salt { get; set; }
        public string Roles { get; set; }
        List<String> Rol;
        
        public IIdentity Identity { get; set; }

        public UsuarioPrincipal(IIdentity identidad, List<String> Rol)
        {
            this.Rol = Rol;
            this.Identity = identidad;
        }



        public bool IsInRole(string role)
        {
            bool existe = this.Roles.Contains(role);
            return existe;
        }
    }
}