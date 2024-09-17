using Domain.Entities.Complex;

namespace DAL.Repositories
{
    public interface IEquipmentRepository
    {
        IEnumerable<EquipmentCx> GetEquipmentList();
    }
}
