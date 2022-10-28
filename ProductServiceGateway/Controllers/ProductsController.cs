using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductServiceGateway.CommonBO;
using ProductServiceGateway.Interfaces;

namespace ProductServiceGateway.Controllers
{
    public class ProductsController : RouteController 
    {
        protected ResponseMessegeBO _response;
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
            this._response = new ResponseMessegeBO();
        }


        [HttpGet]
        public async Task<Object> Get()
        {
            try
            {
                IEnumerable<ProductBO> productsBo = await _productService.GetProducts();
                return _response.Result = productsBo;

            } catch (Exception ex)
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
                ProductBO productsBo = await _productService.GetProductById(id);
                return _response.Result = productsBo;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("create")]
        public async Task<Object> Create([FromBody]ProductBO product)
        {
            try
            {
                ProductBO productsBo = await _productService.CreateProduct(product);
                return _response.Result = productsBo;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMesseges = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("update")]
        public async Task<Object> Update([FromBody] ProductBO product)
        {
            try
            {
                product.CreatedDate = DateTime.Now; 
                ProductBO productsBo = await _productService.UpdateProduct(product);
                return _response.Result = productsBo;

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
                var result = await _productService.DeleteProduct(id);
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
