//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParallelTypeSystem.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class FileVersions
    {
        public int Id { get; set; }
        public int FileId { get; set; }
        public string Directory { get; set; }
        public int Version { get; set; }
        public string Changes { get; set; }
        public System.DateTime ModifiedAt { get; set; }
    
        public virtual Files Files { get; set; }
    }
}
