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
    
    public partial class Address
    {
        public Address()
        {
            this.Client_Address = new HashSet<Client_Address>();
        }
    
        public int adr_id { get; set; }
        public string adr_line_1 { get; set; }
        public string adr_line_2 { get; set; }
        public string adr_city { get; set; }
        public string post_code { get; set; }
    
        public virtual ICollection<Client_Address> Client_Address { get; set; }
    }
}