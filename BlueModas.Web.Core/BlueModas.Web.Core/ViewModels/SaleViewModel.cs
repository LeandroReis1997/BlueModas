using System;

namespace BlueModas.Web.Core.ViewModels
{
    public class SaleViewModel
    {
        public Guid SaleId { get; set; }
        public Guid ProductId { get; set; }
        public int NumberOrder { get; set; }
    }
}
