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
    
    public partial class Material_SOW
    {
        public int mat_sow_id { get; set; }
        public Nullable<int> sow_id { get; set; }
        public Nullable<int> mat_id { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual Scope_of_Work Scope_of_Work { get; set; }
    }
}