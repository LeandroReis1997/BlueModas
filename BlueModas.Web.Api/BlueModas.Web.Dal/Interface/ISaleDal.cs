using BlueModas.Web.Info.Entities;
using System.Threading.Tasks;

namespace BlueModas.Web.Dal.Interface
{
    public interface ISaleDal
    {
        Task<SaleInfo> AddSaleAsync(SaleInfo sale);
    }
}
