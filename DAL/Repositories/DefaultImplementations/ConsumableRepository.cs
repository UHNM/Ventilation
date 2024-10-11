
using DAL.Contexts;

namespace DAL.Repositories.DefaultImplementations
{
    public class ConsumableRepository : Repository, IConsumableRepository
    {
        public ConsumableRepository(IVentilationContext context)
          : base(context)
        {
        }
    }
}
