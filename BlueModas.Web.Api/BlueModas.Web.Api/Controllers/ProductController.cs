using System;
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
    [Route("webapi/product")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductBll _productBll;
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper, IProductBll productBll)
        {
            _productBll = productBll;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<ProductListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<ProductListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(ProductListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetAllProduct()
        {
            return Ok(_mapper.Map<IEnumerable<ProductListDTO>>(_productBll.GetAllProduct()));
        }


        [HttpGet("{id}")]
        [Produces(typeof(IEnumerable<ProductListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(ProductListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetByProductId(Guid id)
        {
            if (_productBll.GetByProductId(id) == null)
                return NotFound();

            return Ok(_mapper.Map<ProductListDTO>(_productBll.GetByProductId(id)));
        }

        [HttpGet]
        [Route("getbyproductname/{name}")]
        [Produces(typeof(IEnumerable<ProductListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(IEnumerable<ProductListDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "OK", Type = typeof(ProductListDTO))]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult GetByProductName(string name)
        {
            return Ok(_mapper.Map<IEnumerable<ProductListDTO>>(_productBll.GetByProductName(name)));
        }

        [HttpPost]
        [Route("create")]
        [Produces(typeof(IEnumerable<ProductDTO>))]
        [SwaggerResponse((int)HttpStatusCode.Created, Description = "Inserido com sucesso", Type = typeof(ProductDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductDTO productDTO)
        {
            return Ok(await _productBll.AddProductAsync(_mapper.Map<ProductInfo>(productDTO)));
        }

        [HttpPut]
        [Route("update/{id}")]
        [Produces(typeof(IEnumerable<ProductDTO>))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Alterado com sucesso", Type = typeof(ProductDTO))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Requisição mal-formatada")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.Conflict, Description = "Conflito")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public async Task<IActionResult> EditProductAsync(Guid id, [FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
                return BadRequest();

            return Accepted(_mapper.Map<ProductListDTO>(await _productBll.EditProductAsync(id, _mapper.Map<ProductInfo>(productDTO))));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [Produces(typeof(OkResult))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Removido com sucesso")]
        [SwaggerResponse((int)HttpStatusCode.Unauthorized, Description = "Erro de Autenticação")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "Recurso não encontrado")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Erro na API")]
        public IActionResult DeleteProduct(Guid id)
        {
            _productBll.DeleteProduct(id);
            return NoContent();
        }

    }
}