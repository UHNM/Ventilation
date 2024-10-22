
using Domain.Entities.Complex;
using Domain.Models;

namespace BAL.Managers
{
    public interface IStockManager
    {
        Task<List<StockItem>> FindStock(string clinicalTechRef);
        Task<IEnumerable<StockItem>> GetStockList();
        Task<int> SaveStockItem(StockItem stock);
        Task<StockItem> GetStockItem(int stockId);
    }
}
