using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTypeSystem.Models.DomainModels
{
    public partial class FileVersion
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey(nameof(File))]
        public int FileId { get; set; }

        public string Directory { get; set; }
        public int Version { get; set; }
        public string Changes { get; set; }
        public DateTime ModifiedAt { get; set; }

        public virtual File File { get; set; }
    }
}
