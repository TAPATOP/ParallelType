using ParallelTypeSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTypeSystem.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> GetAll();

        User GetByUsername(string username);
    }
}
