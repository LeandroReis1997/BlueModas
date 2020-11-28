using BlueModas.Web.Info.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Web.Dal.Interface
{
    public interface IProductDal
    {
        IEnumerable<ProductInfo> GetAllProduct();
        ProductInfo GetByProductId(Guid id);
        IEnumerable<ProductInfo> GetByProductName(string name);
        Task<ProductInfo> AddProductAsync(ProductInfo product);
        Task<ProductInfo> EditProductAsync(ProductInfo product);
        Guid DeleteProduct(Guid id);
    }
}
