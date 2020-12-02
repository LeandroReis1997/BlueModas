using BlueModas.Web.Core.Service;
using System.Collections.Generic;
using BlueModas.Web.Core.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;

namespace BlueModas.Web.Core.Controllers
{
    public class WelcomeController : Controller
    {
        private readonly IMapper _mapper;

        public WelcomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Route("~/")]
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var productService = new ProductService();
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(await productService.GetAllProduct());
            return View(products);
        }

        [HttpGet]
        [Route("viewproduct/{id}")]
        public async Task<IActionResult> ViewProduct(Guid id)
        {
            var productService = new ProductService();
            var product = _mapper.Map<ProductViewModel>(await productService.GetByProductId(id));
            return View("ViewProduct", product);
        }
    }
}