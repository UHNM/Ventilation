using DAL.Contexts;
using Domain.Entities.Complex;

namespace DAL.Repositories.DefaultImplementations
{
    public class EquipmentRepository : Repository, IEquipmentRepository
    {
        public EquipmentRepository(IVentilationContext context)
            : base(context)
        {
        }

      
    }
}
