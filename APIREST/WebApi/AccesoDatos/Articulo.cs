//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Articulo
    {
        public int idArticulo { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> precio { get; set; }
        public Nullable<decimal> iva { get; set; }
        public Nullable<bool> aplicaIva { get; set; }
        public Nullable<bool> activo { get; set; }
    }
}
