//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infraestructure.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CalificacionUsuario
    {
        public int IdCalificacion { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> Calificacion { get; set; }
        public string Comentario { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
