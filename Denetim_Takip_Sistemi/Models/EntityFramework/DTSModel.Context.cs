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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class denetimtakipsistemiVTEntities3 : DbContext
    {
        public denetimtakipsistemiVTEntities3()
            : base("name=denetimtakipsistemiVTEntities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<belge> belge { get; set; }
        public virtual DbSet<belge_tipi> belge_tipi { get; set; }
        public virtual DbSet<bitis_tarihi> bitis_tarihi { get; set; }
        public virtual DbSet<denetim> denetim { get; set; }
        public virtual DbSet<dosya_bilgisi> dosya_bilgisi { get; set; }
        public virtual DbSet<kullanici> kullanici { get; set; }
        public virtual DbSet<nott> nott { get; set; }
    }
}
