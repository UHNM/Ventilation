
using DAL.Repositories;
using Domain.Entities.Complex;
using Domain.Models.EquipmentDetails;

namespace BAL.Managers.DefaultImplementations
{
    public class EquipmentTypeManager : IEquipmentTypeManager
    {
        private readonly IEquipmentTypeRepository _dynamicResponseRepository;


        public EquipmentTypeManager(IEquipmentTypeRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }

        public List<EquipmentType> GetEquipmentTypes()
        {
            var dto = _dynamicResponseRepository.GetEquipmentTypes();
            return GetEquipmentTypesFromDto(dto);
        }

        private static List<EquipmentType> GetEquipmentTypesFromDto(IEnumerable<EquipmentTypeCx> Dto)
        {
            if (Dto != null)
            {
                List<EquipmentType> Types = new List<EquipmentType>();

                foreach (EquipmentTypeCx item in Dto)
                {
                    EquipmentType e = new EquipmentType();
                    e.Id = item.Id;
                    e.EquipmentTypeName = item.EquipmentTypeName;
                    e.Available = item.Available;
                    e.CreatedBy = item.CreatedBy;
                    e.CreatedDate = item.CreatedDate;
                    e.DeletedDate = item.DeletedDate;
                    e.DeletedBy = item.DeletedBy;
                    Types.Add(e);
                }

                return Types;
            }
            return null;
        }
    }
}
