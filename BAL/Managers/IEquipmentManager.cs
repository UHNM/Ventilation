
using Domain.Entities.Complex;
using Domain.Models.EquipmentDetails;
using System.Reflection.Metadata;

namespace BAL.Managers
{
    public interface IEquipmentManager
    {
        List<Equipment> GetEquipmentList();
       
    }
}
