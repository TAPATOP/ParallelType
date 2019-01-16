using ParallelTypeSystem.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParallelTypeSystem.Web.Models
{
    public class DocumentViewModel
    {
        public bool IsSet { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Guid { get; set; }

        public List<FileDTO> Files { get; set; }
    }
}