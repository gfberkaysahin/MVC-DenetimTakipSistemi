//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Denetim_Takip_Sistemi.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class belge_tipi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public belge_tipi()
        {
            this.belge = new HashSet<belge>();
        }
    
        public int belge_tipi_id { get; set; }
        public string belge_tipi_tipi { get; set; }
        public string belge_tipi_durum { get; set; }
        public string belge_tipi_acklm { get; set; }
        public string belge_tipi_eklyn_kllnc { get; set; }
        public string belge_tipi_gncllyn_kllnc { get; set; }
        public Nullable<System.DateTime> belge_tipi_eklnm_trh { get; set; }
        public Nullable<System.DateTime> belge_tipi_gncllnm_trh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<belge> belge { get; set; }
    }
}