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
    
    public partial class CAT_CONDOMINIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CAT_CONDOMINIO()
        {
            this.CAT_VIVIENDA = new HashSet<CAT_VIVIENDA>();
            this.Tbl_DocumentosCondominio = new HashSet<Tbl_DocumentosCondominio>();
        }
    
        public int Id_Condominio { get; set; }
        public string Condominio { get; set; }
        public bool Activo { get; set; }
        public string DemMun { get; set; }
        public string Colonia { get; set; }
        public Nullable<int> Cp { get; set; }
        public string Clave { get; set; }
        public Nullable<int> Id_Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAT_VIVIENDA> CAT_VIVIENDA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_DocumentosCondominio> Tbl_DocumentosCondominio { get; set; }
    }
}
