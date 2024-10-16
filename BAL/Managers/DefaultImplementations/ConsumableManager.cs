
using DAL.Repositories;
using Domain.Entities.Complex;
using Domain.Models;

namespace BAL.Managers.DefaultImplementations
{
    public class ConsumableManager : IConsumableManager
    {

        private readonly IConsumableRepository _dynamicResponseRepository;


        public ConsumableManager(IConsumableRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }

        public async Task<Consumable> GetConsumable(int consumableId)
        {
            var dto = await _dynamicResponseRepository.GetConsumable(consumableId);


            return await Task.FromResult(GetConsumableFromDto(dto));
        }

        private static Consumable GetConsumableFromDto(ConsumableCx Dto)
        {
            if (Dto != null)
            {
                Consumable Consumable = new Consumable();

                Consumable.Id = Dto.Id;
                Consumable.EquipmentName = Dto.EquipmentName;
                Consumable.EquipmentId = Dto.EquipmentId;
                Consumable.EquipmentType = Dto.EquipmentType;
                Consumable.SerialNumber = Dto.SerialNumber;
                Consumable.SupplierName = Dto.SupplierName; 
                Consumable.ConsumableDate = Dto.ConsumableDate;
                Consumable.LoanId   = Dto.LoanId;
                Consumable.DeliveryMethod = Dto.DeliveryMethod;
                Consumable.Comments = Dto.Comments; 
                return Consumable;
            }
            return null;
        }
    }
}
