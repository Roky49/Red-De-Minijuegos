﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MinijuegosContexto : DbContext
    {
        public MinijuegosContexto()
            : base("name=MinijuegosContexto")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Juego> Juego { get; set; }
        public virtual DbSet<Partida> Partida { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<RANKING> RANKING { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<MostrarPerfil> MostrarPerfil { get; set; }
    
        public virtual ObjectResult<PAGINAR_TODOS_Puntos_Result> PAGINAR_TODOS_Puntos(Nullable<int> clave, ObjectParameter tOTALREGISTROS)
        {
            var claveParameter = clave.HasValue ?
                new ObjectParameter("clave", clave) :
                new ObjectParameter("clave", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PAGINAR_TODOS_Puntos_Result>("PAGINAR_TODOS_Puntos", claveParameter, tOTALREGISTROS);
        }
    }
}
