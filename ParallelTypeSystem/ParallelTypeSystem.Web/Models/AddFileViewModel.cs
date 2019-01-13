using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParallelTypeSystem.Web.Models
{
    public class AddFileViewModel
    {
        [Required]
        public string Name { get; set; }

        public bool PublicReadAll { get; set; }

        public bool PublicWriteAll { get; set; }
    }
}