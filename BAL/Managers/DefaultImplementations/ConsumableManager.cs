
using DAL.Repositories;
using Domain.Entities.Complex;
using Domain.Models;
using System.Diagnostics;
using System.Runtime.Versioning;

namespace BAL.Managers.DefaultImplementations
{
    public class ConsumableManager : IConsumableManager
    {

        private readonly IConsumableRepository _dynamicResponseRepository;


        public ConsumableManager(IConsumableRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }

        public async Task<ConsumableDetail> GetConsumable(int? consumableId, int? loanId)
        {
            var dto = await _dynamicResponseRepository.GetConsumable(consumableId, loanId);

            return await Task.FromResult(GetConsumableDetailFromDto(dto));
        }

        //TODO: we could spilt the equipment list out into a separate method and do a Task.WhenAll in the manager??
        private static ConsumableDetail GetConsumableDetailFromDto(ConsumableDetailCx Dto)
        {
            if (Dto != null)
            {
                ConsumableDetail detail = new ConsumableDetail();

                Consumable Consumable = new Consumable();

                Consumable.Id = Dto.Consumable.Id;
                Consumable.EquipmentName = Dto.Consumable.EquipmentName;
                Consumable.EquipmentId = Dto.Consumable.EquipmentId;
                Consumable.EquipmentType = Dto.Consumable.EquipmentType;
                Consumable.EquipmentTypeId = Dto.Consumable.EquipmentTypeId;
                Consumable.SerialNumber = Dto.Consumable.SerialNumber;
                Consumable.SupplierName = Dto.Consumable.SupplierName; 
                Consumable.ConsumableDate = Dto.Consumable.ConsumableDate;
                Consumable.LoanId   = Dto.Consumable.LoanId;
                Consumable.DeliveryMethod = Dto.Consumable.DeliveryMethod;
                Consumable.Comments = Dto.Consumable.Comments; 
                detail.ConsumableSummary = Consumable;

               
                List<LookUp> deliveryMethods = new List<LookUp>();

                foreach (LookupCx method in Dto.DeliveryMethods)
                {
                    LookUp l = new LookUp();
                    l.Key = method.Key;
                    l.Value = method.Value;

                    deliveryMethods.Add(l);
                }

                detail.DeliveryMethods = deliveryMethods;

                List<EquipmentType> eTypes = new List<EquipmentType>();

                foreach (EquipmentTypeCx etype in Dto.EquipmentTypes)
                {
                    EquipmentType t = new EquipmentType();
                    t.Id = etype.Id;
                    t.EquipmentTypeName = etype.EquipmentTypeName;


                    eTypes.Add(t);
                }

                List<EquipmentBase> equip = new List<EquipmentBase>();

                foreach (EquipmentBaseCx ebase in Dto.EquipmentList)
                {
                    EquipmentBase b = new EquipmentBase();
                    b.EquipmentTypeId = ebase.EquipmentTypeId;
                    b.EquipmentId = ebase.EquipmentId;
                    b.EquipmentName = ebase.EquipmentName;

                    equip.Add(b);
                }

                detail.DeliveryMethods = deliveryMethods;
                detail.EquipmentTypes = eTypes;
                detail.EquipmentList = equip;



                return detail;
            }
            return null;
        }

        public async Task<int> SaveConsumable(Consumable consumable)
        {
            var dto = await _dynamicResponseRepository.SaveConsumable(consumable);
            return await Task.FromResult(dto);
        }
    }
}
