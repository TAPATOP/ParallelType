using ParallelTypeSystem.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTypeSystem.Interfaces
{
    public interface IDocumentService
    {
        void AddFile(File file);
    }
}
