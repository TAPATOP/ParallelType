using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParallelTypeSystem.Web.Models
{
    public class ChangesViewModel
    {
        public List<SingleChange> Changes { get; set; }
    }

    public class SingleChange
    {
        public ChangeType ChangeType { get; set; }

        public int Position { get; set; }

        public string Value { get; set; }
    }

    public enum ChangeType
    {
        Add,
        Delete
    }
}