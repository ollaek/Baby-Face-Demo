//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace db
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BabyName { get; set; }
        public Nullable<int> CoverId { get; set; }
        public Nullable<int> PagesCount { get; set; }
        public string Path { get; set; }
        public Nullable<int> CharacterId { get; set; }
    
        public virtual Character Character { get; set; }
    }
}