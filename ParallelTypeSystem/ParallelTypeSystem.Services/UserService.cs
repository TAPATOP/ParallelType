using ParallelTypeSystem.Data;
using ParallelTypeSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ParallelTypeSystem.Services
{
    public class UserService : IUserService
    {
        private ParallelTypeSystemEntities dbContext;
        private IDbFactory dbFactory { get; set; }

        public UserService(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public ParallelTypeSystemEntities DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.GetContext()); }
        }

        public IQueryable<User> GetAll()
        {
            var result = this.DbContext.Users.AsNoTracking();
            return result;
        }

        public User GetByUsername(string username)
        {
            var result = this.GetAll().FirstOrDefault(x => x.Username == username);
            return result;
        }
    }
}
