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
    using System.Web.Mvc;

    public partial class Juego
    {
        public string Nombre { get; set; }
        public Nullable<int> Tipo { get; set; }
        public Nullable<int> Nveces { get; set; }
        public Nullable<int> Valoracion { get; set; }
        public string imagen { get; set; }
        [AllowHtml]
        public string css { get; set; }
        [AllowHtml]
        public string scritp { get; set; }
        [AllowHtml]
        public string hyml { get; set; }
    }
}
