
using Domain.Entities.Complex;
using Domain.Models;

namespace DAL.Repositories
{
    public interface IStockRepository
    {
        Task<IEnumerable<StockItemCx>> FindStock(string clinicalTechRef);

      
    }
}
