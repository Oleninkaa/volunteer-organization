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
    
    public partial class Vydatkovy_ko
    {
        public int ID { get; set; }
        public string number { get; set; }
        public System.DateTime date { get; set; }
        public decimal sum { get; set; }
        public string reason { get; set; }
        public int balance_ID { get; set; }
    
        public virtual Balance Balance { get; set; }
        public virtual Dohidna_n Dohidna_n { get; set; }
    }
}
