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
    
    public partial class File
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public File()
        {
            this.FileVersions = new HashSet<FileVersion>();
            this.UsersFiles = new HashSet<UsersFile>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Guid { get; set; }
        public string CreatorId { get; set; }
        public bool PublicReadAll { get; set; }
        public bool PublicWriteAll { get; set; }
        public System.DateTime CreatedAt { get; set; }
    
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileVersion> FileVersions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersFile> UsersFiles { get; set; }
    }
}
