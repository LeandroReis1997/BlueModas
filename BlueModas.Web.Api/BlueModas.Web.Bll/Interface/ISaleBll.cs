using BlueModas.Web.Info.Entities;
using System.Threading.Tasks;

namespace BlueModas.Web.Bll.Interface
{
    public interface ISaleBll
    {
        Task<SaleInfo> AddSaleAsync(SaleInfo sale);
    }
}
