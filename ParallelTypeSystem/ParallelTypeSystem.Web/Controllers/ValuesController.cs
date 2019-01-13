using AutoMapper.QueryableExtensions;
using ParallelTypeSystem.Data.Repositories;
using ParallelTypeSystem.Models.DomainModels;
using ParallelTypeSystem.Models.DTOs;
using System.Collections.Generic;
using System.Web.Http;

namespace ParallelTypeSystem.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IGenericRepository<User> userRepository;

        public ValuesController(IGenericRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
