//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biblioteka.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tag
    {
        public int IdTag { get; set; }
        public int BookIdBook { get; set; }
        public string TagName { get; set; }
    
        public virtual Book Book { get; set; }
    }
}