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
    
    public partial class MC_remain
    {
        public int ID { get; set; }
        public int mc_ID { get; set; }
        public Nullable<int> amount { get; set; }
    
        public virtual MC MC { get; set; }
    }
}
