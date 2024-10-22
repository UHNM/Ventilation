
using DAL.Repositories;
using Domain.Entities.Complex;
using Domain.Models;
using Domain.Models.EquipmentDetails;


namespace BAL.Managers.DefaultImplementations
{
    public class EquipmentManager : IEquipmentManager
    {
        private readonly IEquipmentRepository _dynamicResponseRepository;


        public EquipmentManager(IEquipmentRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }

        public async Task<List<EquipmentProperty>> GetEquipmentProperties(int? equipmentId)
        {
            var dto = await _dynamicResponseRepository.GetEquipmentProperties(equipmentId);
            return await Task.FromResult(GetEquipmentPropertyFromDto(dto));
        }

        private static List<EquipmentProperty> GetEquipmentPropertyFromDto(IEnumerable<EquipmentPropertyCx> Dto)
        {
            if (Dto != null)
            {
                List<EquipmentProperty> equipProperties = new List<EquipmentProperty>();

                foreach (EquipmentPropertyCx equip in Dto)
                {
                    EquipmentProperty s = new EquipmentProperty();
                    s.Id = equip.Id;
                    s.EquipmentId = equip.EquipmentId;
                    s.Required = equip.Required;
                    s.uiControlType = equip.uiControlType;
                    s.Type = equip.Type;
                    s.Order = equip.Order;
                    s.DisplayName = equip.DisplayName;  
                   
                    equipProperties.Add(s);
                }

                return equipProperties;
            }
            return null;
        }

        public async Task<IEnumerable<EquipmentBase>> GetEquipmentList()
        {
            var dto = await _dynamicResponseRepository.GetEquipmentList();
            return await Task.FromResult(GetEquipmentFromDto(dto));
        }

        //public async Task<List<EquipmentBase>> FindEquipment(string equipmentName)
        //{
        //    var dto = await _dynamicResponseRepository.FindEquipment(equipmentName);
        //    return await Task.FromResult(GetEquipmentFromDto(dto));
        //}

        private static List<EquipmentBase> GetEquipmentFromDto(IEnumerable<EquipmentBaseCx> Dto)
        {
            if (Dto != null)
            {
                List<EquipmentBase> equipmentItems = new List<EquipmentBase>();

                foreach (EquipmentBaseCx equip in Dto)
                {
                    EquipmentBase s = new EquipmentBase();
                    s.EquipmentId = equip.EquipmentId;
                    s.EquipmentName = equip.EquipmentName;
                    s.EquipmentType = equip.EquipmentType;
                    s.SerialNumber  = equip.SerialNumber;
                    s.SupplierName  = equip.SupplierName;
                    s.EquipmentTypeId = equip.EquipmentTypeId;  

                    equipmentItems.Add(s);
                }

                return equipmentItems;
            }
            return null;
        }
    }
}
