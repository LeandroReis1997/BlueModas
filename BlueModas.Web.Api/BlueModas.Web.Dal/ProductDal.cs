using BlueModas.Web.Dal.Interface;
using BlueModas.Web.Info.Entities;
using BlueModas.Web.Info.SqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Web.Dal
{
    public class ProductDal : IProductDal
    {
        private SqlDbContext _dbContext;
        public ProductDal(SqlDbContext sqlDbContext)
        {
            _dbContext = sqlDbContext;
        }

        public async Task<ProductInfo> AddProductAsync(ProductInfo product)
        {
            await _dbContext.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public Guid DeleteProduct(Guid id)
        {
            var entity = _dbContext.Product.FirstOrDefault(x => x.ProductId.Equals(id));
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
            return id;
        }

        public async Task<ProductInfo> EditProductAsync(ProductInfo product)
        {
            _dbContext.Update(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public IEnumerable<ProductInfo> GetAllProduct()
        {
            return _dbContext.Product.ToList().OrderBy(x => x.ProductName);
        }

        public ProductInfo GetByProductId(Guid id)
        {
            return _dbContext.Product.First(x => x.ProductId.Equals(id));
        }

        public IEnumerable<ProductInfo> GetByProductName(string name)
        {
            return _dbContext.Product.Where(x => x.ProductName.Contains(name));
        }
    }
}
