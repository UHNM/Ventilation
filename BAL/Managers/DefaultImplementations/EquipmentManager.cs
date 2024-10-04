
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

       
    }
}
