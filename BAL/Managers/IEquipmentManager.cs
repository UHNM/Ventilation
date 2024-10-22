using Domain.Entities.Complex;
using Domain.Models;

namespace BAL.Managers
{
    public interface IEquipmentManager
    {
      
        Task<List<EquipmentProperty>> GetEquipmentProperties(int? equipmentId);
        Task<IEnumerable<EquipmentBase>> GetEquipmentList();
    }
}
