//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminVivienda2.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CAT_VIVIENDAS
    {
        public int Id_Vivienda { get; set; }
        public string Calle { get; set; }
        public string NumExt { get; set; }
        public string NumInt { get; set; }
        public string Lote { get; set; }
        public Nullable<int> id_Propietario { get; set; }
        public Nullable<int> id_TipoVivienda { get; set; }
        public Nullable<int> id_Condominio { get; set; }
        public Nullable<bool> Activo { get; set; }
        public string Vivienda { get; set; }
    
        public virtual CAT_CONDOMINIOS CAT_CONDOMINIOS { get; set; }
        public virtual CAT_PERSONAS CAT_PERSONAS { get; set; }
    }
}
