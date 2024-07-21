using Core.Entity;
using DTO.Product;
using Microsoft.AspNetCore.Mvc;
using Services;
using WASA_DTOLib.Product;

namespace WASA_API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ProductEntity?> Add(AddProductRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _productService.AddProduct(request);
            }
            return null;
        }  

        // TODO: Remove productCode in request

        [HttpPut]
        public async Task<ProductEntity?> Update(UpdateProductRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _productService.UpdateProduct(request.ProductCode, request);
            }
            return null;
        }

        [HttpPost]
        public async Task<ProductEntity?> ShowByProductCode(GetProductByCodeRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _productService.ShowByProductCode(request.ProductCode);
            }
            return null;
        }

        [HttpPost]
        public async Task<List<ProductEntity>?> ShowAll()
        {
            if(ModelState.IsValid)
            {
                return await _productService.ShowAll();
            }
            return null;
        }

        [HttpPost]
        public async Task<List<ProductEntity>?> ShowByCategory(GetProductByQueryRequest request)
        {
            if(ModelState.IsValid)
            {
                return await _productService.ShowByCategory(request.Query);
            }
            return null;
        }

        [HttpPost]
        public async Task<IEnumerable<ProductEntity>?> ShowByQuery(GetProductByQueryRequest request)
        {   
            if (ModelState.IsValid)
            {
                return await _productService.ShowByQuery(request.Query);
            }
            return null;
        }

        [HttpDelete]
        public void Delete(DeleteProductRequest request)
        {
            if(ModelState.IsValid)
            {
                _productService.Delete(request.ProductCode);
            }
        }
    }
}
