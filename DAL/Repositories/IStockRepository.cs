
using Domain.Entities.Complex;
using Domain.Models;

namespace DAL.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<StockItemCx>> FindStock(string clinicalTechRef);

        Task<IEnumerable<StockItemCx>> GetStockList();

        Task<int> SaveStockItem(StockItem item);

    }
}
