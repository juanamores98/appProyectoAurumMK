﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infraestructure.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AuronMkEntities : DbContext
    {
        public AuronMkEntities()
            : base("name=AuronMkEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CalificacionUsuario> CalificacionUsuario { get; set; }
        public virtual DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<ContactoProveedor> ContactoProveedor { get; set; }
        public virtual DbSet<CostoEnvio> CostoEnvio { get; set; }
        public virtual DbSet<EstadoSistema> EstadoSistema { get; set; }
        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<InventarioProducto> InventarioProducto { get; set; }
        public virtual DbSet<MotivoMovimiento> MotivoMovimiento { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoProducto> PedidoProducto { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<RegistroMovimiento> RegistroMovimiento { get; set; }
        public virtual DbSet<RegistroProducto> RegistroProducto { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
        public virtual DbSet<TipoMovimiento> TipoMovimiento { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
