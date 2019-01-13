using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTypeSystem.Models.DomainModels
{
    public partial class PermissionType
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        
        public virtual ICollection<UsersFile> UsersFiles { get; set; }
    }
}
