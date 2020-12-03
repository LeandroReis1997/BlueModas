using System.Threading.Tasks;
using AutoMapper;
using BlueModas.Web.Core.Service;
using BlueModas.Web.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlueModas.Web.Core.Controllers
{
    public class SaleController : Controller
    {
        private readonly IMapper _mapper;

        public SaleController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Route("createsale")]
        public async Task<IActionResult> CreateSale(SaleViewModel sale)
        {
            var saleService = new SaleService();
            var createSale = _mapper.Map<SaleViewModel>(await saleService.AddSale(sale));
            return View("Views/Welcome/Purchase.cshtml");
        }
    }
}