using BlueModas.Web.Bll.Interface;
using BlueModas.Web.Dal.Interface;
using BlueModas.Web.Info.Entities;
using System;
using System.Threading.Tasks;

namespace BlueModas.Web.Bll
{
    public class SaleBll : ISaleBll
    {
        private ISaleDal _dal;
        public SaleBll(ISaleDal dal)
        {
            _dal = dal;
        }

        public Task<SaleInfo> AddSaleAsync(SaleInfo sale)
        {
            Random randNum = new Random();
            sale.NumberOrder = randNum.Next(2000000000);
            return _dal.AddSaleAsync(sale);
        }
    }
}
