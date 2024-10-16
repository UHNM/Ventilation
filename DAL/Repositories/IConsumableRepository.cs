using Domain.Entities.Complex;
using Domain.Models;

namespace DAL.Repositories
{
    public interface IConsumableRepository
    {
        Task<ConsumableCx> GetConsumable(int consumableId);

        Task<int> SaveConsumable(Consumable consumable);

    }
}
