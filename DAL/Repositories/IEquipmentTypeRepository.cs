
using Domain.Entities.Complex;

namespace DAL.Repositories
{
    public interface IEquipmentTypeRepository
    {
        IEnumerable<EquipmentTypeCx> GetEquipmentTypes();
    }
}
