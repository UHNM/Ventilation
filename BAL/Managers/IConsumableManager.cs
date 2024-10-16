
using Domain.Models;

namespace BAL.Managers
{
    public interface IConsumableManager
    {
        Task<ConsumableDetail> GetConsumable(int? consumableId, int? loanId);
        Task<int> SaveConsumable(Consumable consumabe);

    }
}
