//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PharmancySQL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> DrugCount { get; set; }
        public Nullable<int> TypeId { get; set; }
    
        public virtual DrugsType DrugsType { get; set; }
    }
}