using AutoMapper;
using ParallelTypeSystem.Models.DomainModels;
using ParallelTypeSystem.Models.DTOs;

namespace ParallelTypeSystem.Web.Utils
{
    public static class AutomapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<User, UserDTO>();
            });
        }
    }
}
