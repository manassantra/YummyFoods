using ProductServiceGateway.CommonBO;

namespace ProductServiceGateway.Interfaces
{
    public interface IProductService
    {
        // Product
        Task<IEnumerable<ProductBO>> GetProducts();
        Task<ProductBO> GetProductById(int productId);
        Task<ProductBO> CreateProduct(ProductBO productBo);
        Task<ProductBO> UpdateProduct(ProductBO productBO);
        Task<bool> DeleteProduct(int productId);

        // Product Category
        Task<IEnumerable<ProductCategoryBO>> GetProductCategory();
        Task<ProductCategoryBO> GetProductCategoryById(int categoryId);
        Task<ProductCategoryBO> CreateProductCategory(ProductCategoryBO productCategoryBO);
        Task<ProductCategoryBO> UpdateProductCategory(ProductCategoryBO productCategoryBO);
        Task<bool> DeleteProductCategory(int categoryId);
    }
}
