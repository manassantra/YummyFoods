using YummyFood.Web.CommonBO;

namespace YummyFood.Web.Interfaces
{
    public interface IProductService
    {
        Task<T> GetAllProductAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductBO productBO);
        Task<T> UpdateProductAsync<T>(ProductBO productBO);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
