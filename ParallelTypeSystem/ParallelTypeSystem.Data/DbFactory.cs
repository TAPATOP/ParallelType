using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTypeSystem.Data
{
    public class DbFactory : IDbFactory
    {
        ParallelTypeSystemEntities dbContext;

        public ParallelTypeSystemEntities GetContext()
        {
            return dbContext ?? (dbContext = new ParallelTypeSystemEntities());
        }
    }
}
