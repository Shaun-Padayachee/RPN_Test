//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rpnTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quotation
    {
        public Quotation()
        {
            this.Quote_SOW = new HashSet<Quote_SOW>();
        }
    
        public string quote_no { get; set; }
        public Nullable<System.DateTime> quote_date { get; set; }
        public string person { get; set; }
        public string descript { get; set; }
        public Nullable<decimal> price_ex_vat { get; set; }
        public string set_1 { get; set; }
        public string set_2 { get; set; }
        public string set_3 { get; set; }
        public string set_4 { get; set; }
        public string set_5 { get; set; }
        public string set_6 { get; set; }
        public Nullable<int> client_id { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual ICollection<Quote_SOW> Quote_SOW { get; set; }
    }
}
