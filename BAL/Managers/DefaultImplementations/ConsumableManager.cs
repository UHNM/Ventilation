
using DAL.Repositories;

namespace BAL.Managers.DefaultImplementations
{
    public class ConsumableManager : IConsumableManager
    {

        private readonly IConsumableRepository _dynamicResponseRepository;


        public ConsumableManager(IConsumableRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }
    }
}
