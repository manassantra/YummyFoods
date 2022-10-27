using AutoMapper;
using OrderServiceGateway.CommonBO;
using OrderServiceGateway.Models;

namespace OrderServiceGateway
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderBO, Order>();
                config.CreateMap<Order, OrderBO>();
            });
            return mappingConfig;
        }
    }
}
