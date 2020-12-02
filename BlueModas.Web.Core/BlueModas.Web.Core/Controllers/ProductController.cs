using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BlueModas.Web.Core.Service;
using BlueModas.Web.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlueModas.Web.Core.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }
               
        public async Task<IActionResult> Index()
        {
            var productService = new ProductService();
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(await productService.GetAllProduct());
            return View(products);
        }

        [Route("addproduct")]
        public IActionResult AddProduct()
        {
            return View("create", new ProductViewModel());
        }

        [HttpPost]
        [Route("createproduct")]
        public async Task<IActionResult> CreateProduct(ProductViewModel producct)
        {
            var productService = new ProductService();
            var createProduct = _mapper.Map<ProductViewModel>(await productService.AddProduct(producct));
            return RedirectToAction("Index", createProduct);
        }

        [HttpGet]
        [Route("updateproduct/{id}")]
        public async Task<IActionResult> EditProduct(Guid id)
        {
            var productService = new ProductService();
            var product = _mapper.Map<ProductViewModel>(await productService.GetByProductId(id));
            return View("Edit", product);
        }

        [HttpPost]
        [Route("updateproduct/{id}")]
        public async Task<IActionResult> EditProduct(Guid id, ProductViewModel product)
        {
            var productService = new ProductService();
            var update = _mapper.Map<ProductViewModel>(await productService.EditProduct(id, product));
            return RedirectToAction("Index", update);
        }

        [Route("deleteproduct/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var productService = new ProductService();
            _mapper.Map<ProductViewModel>(await productService.DeleteProduct(id));
            return RedirectToAction("Index");
        }
    }
}