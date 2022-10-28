
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YummyFood.Web.CommonBO;
using YummyFood.Web.Interfaces;


namespace YummyFood.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductBO>? list = new();
            var response = await _productService.GetAllProductAsync<ResponseMessegeBO>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductBO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }


        [Route("Create")]
        public async Task<IActionResult> CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductBO productBO)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync<ResponseMessegeBO>(productBO);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            return View(productBO);
        }


        [Route("ProductDetails/{id}")]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var model = new ProductBO();
            var response = await _productService.GetProductByIdAsync<ResponseMessegeBO>(id);
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<ProductBO>(Convert.ToString(response.Result));
            }
            return View(model);
        }



        [Route("EditDetails/{id}")]
        public async Task<IActionResult> EditDetails(int id)
        {
            var model = new ProductBO();
            var response = await _productService.GetProductByIdAsync<ResponseMessegeBO>(id);
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<ProductBO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProduct(ProductBO productBO)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductAsync<ResponseMessegeBO>(productBO);
                if (response != null && response.IsSuccess == true)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            return View(productBO);
        }



        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var model = new ProductBO();
            var response = await _productService.GetProductByIdAsync<ResponseMessegeBO>(id);
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<ProductBO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProductBO product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.DeleteProductAsync<ResponseMessegeBO>(product.ProductId);
                if (response.IsSuccess == true)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            return NotFound();
        }



        [Route("DisableProduct/{id}")]
        public async Task<IActionResult> DisableProduct(int id)
        {
            var model = new ProductBO();
            var response = await _productService.GetProductByIdAsync<ResponseMessegeBO>(id);
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<ProductBO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Disabled(ProductBO productBO)
        {
            productBO.IsActive = false;
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductAsync<ResponseMessegeBO>(productBO);
                if (response != null && response.IsSuccess == true)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            return NoContent();
        }



        [Route("EnableProduct/{id}")]
        public async Task<IActionResult> EnableProduct(int id)
        {
            var model = new ProductBO();
            var response = await _productService.GetProductByIdAsync<ResponseMessegeBO>(id);
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<ProductBO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Enabled(ProductBO productBO)
        {
            productBO.IsActive = true;
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductAsync<ResponseMessegeBO>(productBO);
                if (response != null && response.IsSuccess == true)
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            return NoContent();
        }
    }
}
