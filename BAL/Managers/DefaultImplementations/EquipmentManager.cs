
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
    }
}
