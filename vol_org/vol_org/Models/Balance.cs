//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace vol_org.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Balance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Balance()
        {
            this.Prybutkovy_ko = new HashSet<Prybutkovy_ko>();
            this.Vydatkovy_ko = new HashSet<Vydatkovy_ko>();
        }
    
        public int ID { get; set; }
        public decimal amount { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prybutkovy_ko> Prybutkovy_ko { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vydatkovy_ko> Vydatkovy_ko { get; set; }
    }
}
