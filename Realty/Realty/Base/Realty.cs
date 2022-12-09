//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Realty.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class Realty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Realty()
        {
            this.Transaction = new HashSet<Transaction>();
        }
    
        public int IdRealty { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Square { get; set; }
        public Nullable<int> Floor { get; set; }
        public Nullable<int> Rooms { get; set; }
        public string Address { get; set; }
        public Nullable<int> IdOwnerAccount { get; set; }
        public Nullable<int> IdTypeRealty { get; set; }
        public string img { get; set; }
        public Nullable<int> idStatusRealty { get; set; }
    
        public virtual Accounts Accounts { get; set; }
        public virtual StatusRealty StatusRealty { get; set; }
        public virtual TypeRealty TypeRealty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
