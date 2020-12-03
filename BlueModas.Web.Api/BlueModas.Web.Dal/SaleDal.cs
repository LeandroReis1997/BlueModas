using BlueModas.Web.Dal.Interface;
using BlueModas.Web.Info.Entities;
using BlueModas.Web.Info.SqlDbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Web.Dal
{
   public class SaleDal : ISaleDal
    {
        private SqlDbContext _dbContext;
        public SaleDal(SqlDbContext sqlDbContext)
        {
            _dbContext = sqlDbContext;
        }

        public async Task<SaleInfo> AddSaleAsync(SaleInfo sale)
        {
            await _dbContext.AddAsync(sale);
            await _dbContext.SaveChangesAsync();
            return sale;
        }
    }
}
