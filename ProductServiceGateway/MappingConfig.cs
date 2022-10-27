using AutoMapper;
using ProductServiceGateway.CommonBO;
using ProductServiceGateway.Models;

namespace ProductServiceGateway
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductBO, Product>();
                config.CreateMap<Product, ProductBO>();
                config.CreateMap<ProductCategoryBO, ProductCategory>();
                config.CreateMap<ProductCategory, ProductCategoryBO>();
            });
            return mappingConfig;
        } 
    }
}
