using BlueModas.Web.Core.Service;
using System.Collections.Generic;
using BlueModas.Web.Core.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;



namespace BlueModas.Web.Core.Controllers
{
    public class WelcomeController : Controller
    {
        private readonly IMapper _mapper;

        public WelcomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

       
        public async Task<IActionResult> Index()
        {
            var productService = new ProductService();
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(await productService.GetAllProduct());
            return View(products);
        }
    }
}