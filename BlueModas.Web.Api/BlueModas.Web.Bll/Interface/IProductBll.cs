using BlueModas.Web.Info.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlueModas.Web.Bll.Interface
{
    public interface IProductBll
    {
        IEnumerable<ProductInfo> GetAllProduct();
        ProductInfo GetByProductId(Guid id);
        IEnumerable<ProductInfo> GetByProductName(string name);
        Task<ProductInfo> AddProductAsync(ProductInfo product);
        Task<ProductInfo> EditProductAsync(Guid id, ProductInfo product);
        Guid DeleteProduct(Guid id);
    }
}
