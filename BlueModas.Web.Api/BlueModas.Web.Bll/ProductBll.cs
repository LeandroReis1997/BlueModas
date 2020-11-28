using BlueModas.Web.Bll.Interface;
using BlueModas.Web.Dal.Interface;
using BlueModas.Web.Info.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Web.Bll
{
    public class ProductBll : IProductBll
    {
        private IProductDal _dal;
        public ProductBll(IProductDal dal)
        {
            _dal = dal;
        }

        public async Task<ProductInfo> AddProductAsync(ProductInfo product)
        {
            return await _dal.AddProductAsync(product);
        }

        public Guid DeleteProduct(Guid id)
        {
            return _dal.DeleteProduct(id);
        }

        public async Task<ProductInfo> EditProductAsync(Guid id, ProductInfo product)
        {
            product.ProductId = id;
            return await _dal.EditProductAsync(product);
        }

        public IEnumerable<ProductInfo> GetAllProduct()
        {
            return _dal.GetAllProduct();
        }

        public ProductInfo GetByProductId(Guid id)
        {
            return _dal.GetByProductId(id);
        }

        public IEnumerable<ProductInfo> GetByProductName(string name)
        {
            return _dal.GetByProductName(name);
        }
    }
}
