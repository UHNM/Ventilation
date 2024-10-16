using Domain.Entities.Complex;

namespace DAL.Repositories
{
    public interface IConsumableRepository
    {
        Task<ConsumableCx> GetConsumable(int consumableId);

    }
}
