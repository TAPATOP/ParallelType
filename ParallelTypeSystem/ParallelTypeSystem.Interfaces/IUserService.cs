using ParallelTypeSystem.Models.DTOs;
using System.Linq;

namespace ParallelTypeSystem.Interfaces
{
    public interface IUserService
    {
        IQueryable<UserDTO> GetAll();

        UserDTO GetUser(string username);
    }
}
