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
    
    public partial class T_TransactionInfo
    {
        public int TransactionID { get; set; }
        public int ProductID { get; set; }
        public int TypeOfTransaction { get; set; }
        public int InvoiceID { get; set; }
        public string MFR { get; set; }
        public string Batch { get; set; }
        public string Exp { get; set; }
        public string HSN { get; set; }
        public int Pack { get; set; }
        public int Qty { get; set; }
        public double Rate { get; set; }
        public double Dis { get; set; }
        public string Free { get; set; }
        public double IGST { get; set; }
        public double Amount { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public bool Active { get; set; }
    
        public virtual M_MasterTable M_MasterTable { get; set; }
        public virtual M_MasterTable M_MasterTable1 { get; set; }
        public virtual M_ProductMaster M_ProductMaster { get; set; }
        public virtual T_InvoiceInfo T_InvoiceInfo { get; set; }
    }
}
