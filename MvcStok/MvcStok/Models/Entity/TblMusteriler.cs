//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TblMusteriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblMusteriler()
        {
            this.TblSatislar = new HashSet<TblSatislar>();
        }
    
        public int MUSTERIID { get; set; }

        [Required(ErrorMessage ="Bu Alan� Bo� Ge�emezsiniz..")]
        [StringLength(50,ErrorMessage ="En fazla 50 karakterlik isim giriniz..")]
        public string MUSTERIAD { get; set; }
        public string MUSTERISOYAD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSatislar> TblSatislar { get; set; }
    }
}
