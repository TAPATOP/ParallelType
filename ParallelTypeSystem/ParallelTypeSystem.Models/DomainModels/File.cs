using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParallelTypeSystem.Models.DomainModels
{
    public class File
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public string Guid { get; set; }

        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; }
        public bool PublicReadAll { get; set; }
        public bool PublicWriteAll { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
        public virtual User Creator { get; set; }
    }
}
