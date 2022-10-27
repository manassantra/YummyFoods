using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductServiceGateway.CommonBO;
using ProductServiceGateway.DbContexts;
using ProductServiceGateway.Interfaces;
using ProductServiceGateway.Models;

namespace ProductServiceGateway.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContexts;
        private IMapper _mapper;

        public ProductService(AppDbContext dbContexts, IMapper mapper)
        {
            _dbContexts = dbContexts;
            _mapper = mapper;
        }

        public async Task<ProductBO> CreateProduct(ProductBO productBo)
        {
            Product product = _mapper.Map<ProductBO, Product>(productBo);
            _dbContexts.Products.Add(product);
            await _dbContexts.SaveChangesAsync();
            return _mapper.Map<Product, ProductBO>(product);
        }

        public async Task<ProductCategoryBO> CreateProductCategory(ProductCategoryBO productCategoryBO)
        {
            ProductCategory productCategory = _mapper.Map<ProductCategoryBO, ProductCategory>(productCategoryBO);
            _dbContexts.ProductCategories.Add(productCategory);
            await _dbContexts.SaveChangesAsync();
            return _mapper.Map<ProductCategory, ProductCategoryBO>(productCategory);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                Product product = await _dbContexts.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _dbContexts.Products.Remove(product);
                await _dbContexts.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProductCategory(int categoryId)
        {
            try
            {
                ProductCategory productCategory = await _dbContexts.ProductCategories.FirstOrDefaultAsync(x => x.CategoryId == categoryId);
                if (productCategory == null)
                {
                    return false;
                }
                _dbContexts.ProductCategories.Remove(productCategory);
                await _dbContexts.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ProductBO> GetProductById(int productId)
        {
            Product product = await _dbContexts.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductBO>(product);
        }

        public async Task<IEnumerable<ProductCategoryBO>> GetProductCategory()
        {
            List<ProductCategory> productCategory = await _dbContexts.ProductCategories.ToListAsync();
            return _mapper.Map<List<ProductCategoryBO>>(productCategory);
        }

        public async Task<ProductCategoryBO> GetProductCategoryById(int categoryId)
        {
            ProductCategory productCategory = await _dbContexts.ProductCategories.Where(x => x.CategoryId == categoryId).FirstOrDefaultAsync();
            return _mapper.Map<ProductCategoryBO>(productCategory);
        }

        public async Task<IEnumerable<ProductBO>> GetProducts()
        {
            List<Product> productList = await _dbContexts.Products.ToListAsync();
            return _mapper.Map<List<ProductBO>>(productList);
        }

        public async Task<ProductBO> UpdateProduct(ProductBO productBo)
        {
            var product = _mapper.Map<ProductBO, Product>(productBo);
            if (productBo.ProductId != 0)
            {
                _dbContexts.Products.Update(product);
            }
            await _dbContexts.SaveChangesAsync();
            return _mapper.Map<Product, ProductBO>(product);
        }

        public async Task<ProductCategoryBO> UpdateProductCategory(ProductCategoryBO productCategoryBO)
        {
            var productCategory = _mapper.Map<ProductCategoryBO, ProductCategory>(productCategoryBO);
            if (productCategoryBO.CategoryId != 0)
            {
                _dbContexts.ProductCategories.Update(productCategory);
            }
            await _dbContexts.SaveChangesAsync();
            return _mapper.Map<ProductCategory, ProductCategoryBO>(productCategory);
        }
    }
}
