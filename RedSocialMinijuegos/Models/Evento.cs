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
    
    public partial class Evento
    {
        public string Tipo { get; set; }
        public string Juego { get; set; }
        public Nullable<int> Premio { get; set; }
        public Nullable<int> Coste { get; set; }
        public int IdEvento { get; set; }
        public Nullable<int> IdUsuario { get; set; }
    }
}
