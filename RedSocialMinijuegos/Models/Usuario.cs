//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RedSocialMinijuegos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
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
    }
}