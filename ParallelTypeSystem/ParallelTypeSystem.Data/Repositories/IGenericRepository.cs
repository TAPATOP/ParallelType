using Microsoft.AspNet.Identity.EntityFramework;
using ParallelTypeSystem.Models.DomainModels;
using System.Linq;

namespace ParallelTypeSystem.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IdentityDbContext<User> GetDbContext();

        IQueryable<T> GetAll();

        void Add(T item);

        void Remove(T item);
    }
}
