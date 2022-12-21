using YummyFood.Web.CommonBO;

namespace YummyFood.Web.Interfaces
{
    public interface IProductService
    {
        Task<T> GetAllProductAsync<T>(string token);
        Task<T> GetProductByIdAsync<T>(int id, string token);
        Task<T> CreateProductAsync<T>(ProductBO productBO, string token);
        Task<T> UpdateProductAsync<T>(ProductBO productBO, string token);
        Task<T> DeleteProductAsync<T>(int id, string token);
    }
}
