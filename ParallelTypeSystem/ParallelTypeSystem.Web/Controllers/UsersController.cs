using AutoMapper.QueryableExtensions;
using ParallelTypeSystem.Interfaces;
using ParallelTypeSystem.Models.DTOs;
using System.Web.Http;

namespace ParallelTypeSystem.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route(nameof(GetAll))]
        public IHttpActionResult GetAll()
        {
            var users = this.userService.GetAll();
            return Ok(users);
        }

        [Route(nameof(FindUser))]
        public IHttpActionResult FindUser(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                return BadRequest("Username is required");
            }

            var user = this.userService.GetUser(username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
