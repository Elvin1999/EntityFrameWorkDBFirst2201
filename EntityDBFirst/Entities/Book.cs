//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityDBFirst.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
    }
}
