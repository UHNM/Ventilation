
using Domain.Models;

namespace BAL.Managers
{
    public interface IConsumableManager
    {
        Task<Consumable> GetConsumable(int consumableId);

    }
}
