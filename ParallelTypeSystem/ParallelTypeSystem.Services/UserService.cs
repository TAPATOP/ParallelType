using AutoMapper.QueryableExtensions;
using ParallelTypeSystem.Common;
using ParallelTypeSystem.Data.Repositories;
using ParallelTypeSystem.Interfaces;
using ParallelTypeSystem.Models.DomainModels;
using ParallelTypeSystem.Models.DTOs;
using System.Linq;

namespace ParallelTypeSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IQueryable<UserDTO> GetAll()
        {
            var result = this.userRepository.GetAll().ProjectTo<UserDTO>();
            return result;
        }
        
        public UserDTO GetUser(string username)
        {
            var user = this.GetAll().FirstOrDefault(x => x.Username == username);
            return user;
        }

        public string GetUsername(string userId)
        {
            var user = this.GetAll().FirstOrDefault(x => x.Id == userId);
            string username = user?.Username;
            return username;
        }
    }
}
