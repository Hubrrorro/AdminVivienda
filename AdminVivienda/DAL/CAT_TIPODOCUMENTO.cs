//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminVivienda.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAT_TIPODOCUMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_TIPODOCUMENTO()
        {
            this.Tbl_DocumentosCondominio = new HashSet<Tbl_DocumentosCondominio>();
        }
    
        public int Id_TipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public bool Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DocumentosCondominio> Tbl_DocumentosCondominio { get; set; }
    }
}