

using Microsoft.AspNetCore.Mvc;
using ProductServiceGateway.CommonBO;
using ProductServiceGateway.Interfaces;

namespace ProductServiceGateway.Controllers
{
    public class ProductCategoryController : RouteController
    {
        protected ResponseMessegeBO _response;
        private IProductService _productService;
        public ProductCategoryController(IProductService productService)
        {
            this._response = new ResponseMessegeBO();
            _productService = productService;   
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductCategoryBO> productsCategoryBo = await _productService.GetProductCategory();
                return _response.Result = productsCategoryBo;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet("{id}")]
        public async Task<Object> Get(int id)
        {
            try
            {
                ProductCategoryBO productsCategoryBo = await _productService.GetProductCategoryById(id);
                return _response.Result = productsCategoryBo;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("create")]
        public async Task<Object> Post([FromBody] ProductCategoryBO productCategoryBo)
        {
            try
            {
                ProductCategoryBO productsCategoryBo = await _productService.CreateProductCategory(productCategoryBo);
                return _response.Result = productsCategoryBo;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("update")]
        public async Task<Object> Put([FromBody] ProductCategoryBO productCategoryBo)
        {
            try
            {
                productCategoryBo.CreatedDate = DateTime.Now; 
                ProductCategoryBO productsCategoryBo = await _productService.UpdateProductCategory(productCategoryBo);
                return _response.Result = productsCategoryBo;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id}")]
        public async Task<Object> Delete(int id)
        {
            try
            {
                var result = await _productService.DeleteProductCategory(id);
                return _response.Result = result;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
