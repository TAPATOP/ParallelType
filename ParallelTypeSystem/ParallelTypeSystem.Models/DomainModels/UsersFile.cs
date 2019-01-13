using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTypeSystem.Models.DomainModels
{
    public partial class UsersFile
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(File))]
        public int FileId { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        [ForeignKey(nameof(PermissionType))]
        public int PermissionTypeId { get; set; }

        public virtual File File { get; set; }
        public virtual PermissionType PermissionType { get; set; }
        public virtual User User { get; set; }
    }
}
