
using DAL.Repositories;
using Domain.Entities.Complex;
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

        public List<Equipment> GetEquipmentList()
        {
            var dto = _dynamicResponseRepository.GetEquipmentList();
            return GetEquipmentFromDto(dto);
        }

        private static List<Equipment> GetEquipmentFromDto(IEnumerable<EquipmentCx> Dto)
        {
            if (Dto != null)
            {
                List<Equipment> Equipments = new List<Equipment>();

                foreach (EquipmentCx item in Dto)
                {
                    Equipment e = new Equipment();
                    e.Id = item.Id;
                    e.EquipmentName = item.EquipmentName;
                    e.SupplierId = item.SupplierId;
                    e.Available = item.Available;
                    e.CreatedBy = item.CreatedBy;
                    e.CreatedDate = item.CreatedDate;
                    e.DeletedDate = item.DeletedDate;
                    e.DeletedBy = item.DeletedBy;
                    Equipments.Add(e);
                }

                return Equipments;
            }
            return null;
        }
    }
}
