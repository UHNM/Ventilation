using Domain.Models;

namespace BAL.Managers
{
    public interface IEquipmentManager
    {
        Task<List<EquipmentProperty>> GetEquipmentProperties(int? equipmentId);

    }
}
