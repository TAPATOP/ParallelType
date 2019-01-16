using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParallelTypeSystem.Web.Models
{
    public class ChangesViewModel
    {
        public string Guid { get; set; }

        public List<SingleChange> Changes { get; set; }
    }

    public class SingleChange
    {
        public ChangeType ChangeType { get; set; }

        public int Position { get; set; }
        
        [AllowHtml]
        public string Value { get; set; }
    }

    public enum ChangeType
    {
        Add,
        Delete
    }
}