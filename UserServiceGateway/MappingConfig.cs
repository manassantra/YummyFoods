using AutoMapper;
using UserServiceGateway.CommonBO;
using UserServiceGateway.Models;

namespace UserServiceGateway
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserBO, User>();
                config.CreateMap<User, UserBO>();
            });
            return mappingConfig;
        }
    }
}
