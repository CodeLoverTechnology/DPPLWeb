//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DPPLWeb.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class M_MasterTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public M_MasterTable()
        {
            this.T_TransactionInfo = new HashSet<T_TransactionInfo>();
            this.T_TransactionInfo1 = new HashSet<T_TransactionInfo>();
        }
    
        public int MasterID { get; set; }
        public string MasterValue { get; set; }
        public string TableName { get; set; }
        public int SequenceNo { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_TransactionInfo> T_TransactionInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_TransactionInfo> T_TransactionInfo1 { get; set; }
    }
}