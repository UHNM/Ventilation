using Domain.Entities.Complex;

namespace DAL.Repositories
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<EquipmentPropertyCx>> GetEquipmentProperties(int? equipmentId);
        Task<IEnumerable<EquipmentBaseCx>> GetEquipmentList();
    
    }
}
