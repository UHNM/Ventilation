using Domain.Entities.Complex;
using Domain.Models;

namespace DAL.Repositories
{
    public interface IConsumableRepository
    {
        //covers a get for both new and edit, if a new, we won't have a consumable Id

        Task<ConsumableDetailCx> GetConsumable(int? consumableId, int? loanId);

        Task<int> SaveConsumable(Consumable consumable);

    }
}
