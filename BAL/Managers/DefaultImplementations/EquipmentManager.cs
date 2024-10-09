
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
                    s.EquipmentId  = equip.EquipmentId;
                   // s.EquipmentPropertyName = equip.EquipmentPropertyName;
                   // s.EquipmentPropertyValue = equip.EquipmentPropertyValue;
                    equipProperties.Add(s);
                }

                return equipProperties;
            }
            return null;
        }
    }
}
