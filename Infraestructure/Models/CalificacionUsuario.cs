//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(CalificacionUsuarioMetadata))] 
    public partial class CalificacionUsuario
    {
        public int IdCalificacion { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public Nullable<int> Calificacion { get; set; }
        public string Comentario { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
