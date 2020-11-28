using System;

namespace BlueModas.Web.Api.DTO
{
    public class ProductListDTO
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
