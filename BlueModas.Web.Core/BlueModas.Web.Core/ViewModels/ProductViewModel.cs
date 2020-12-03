﻿using System;

namespace BlueModas.Web.Core.ViewModels
{
    public class ProductViewModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public string Image { get; set; }
    }
}
