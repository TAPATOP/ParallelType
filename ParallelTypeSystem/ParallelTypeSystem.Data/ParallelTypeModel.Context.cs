﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ParallelTypeSystemEntities : DbContext
    {
        public ParallelTypeSystemEntities()
            : base("name=ParallelTypeSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<FileVersions> FileVersions { get; set; }
        public virtual DbSet<PermissionTypes> PermissionTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersFiles> UsersFiles { get; set; }
    }
}
