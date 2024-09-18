using Domain.Models.EquipmentDetails;

namespace BAL.Managers
{
    public interface IEquipmentTypeManager
    {
        List<EquipmentType> GetEquipmentTypes();
    }
}
