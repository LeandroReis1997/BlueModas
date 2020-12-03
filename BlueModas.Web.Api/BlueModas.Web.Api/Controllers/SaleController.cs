using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BlueModas.Web.Api.DTO;
using BlueModas.Web.Bll.Interface;
using BlueModas.Web.Info.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace BlueModas.Web.Api.Controllers
{
    [Route("webapi/sale")]
    [ApiController]
    public class SaleController : Controller
    {
        private ISaleBll _saleBll;
        private readonly IMapper _mapper;
        public SaleController(IMapper mapper, ISaleBll saleBll)
        {
            _saleBll = saleBll;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        [Produces(typeof(IEnumerable<SaleDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(SaleDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> AddSaleAsync([FromBody] SaleDTO saleDTO)
        {
            return Ok(await _saleBll.AddSaleAsync(_mapper.Map<SaleInfo>(saleDTO)));
        }
    }
}