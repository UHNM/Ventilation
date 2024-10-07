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

        public async Task<IEnumerable<EquipmentPropertyCx>> GetEquipmentProperties(int? equipmentId)
        {
            IEnumerable<EquipmentPropertyCx> EquipProperties = new List<EquipmentPropertyCx>();

            EquipmentPropertyCx q = new EquipmentPropertyCx();
            q.Id = 1;
            q.EquipmentId = 1000;
            q.EquipmentPropertyName = "Mode";
            q.EquipmentPropertyValue = "My Mode"; //not sure if we need this or if its the prescription property value

            EquipmentPropertyCx q2 = new EquipmentPropertyCx();
            q2.Id = 2;
            q2.EquipmentId = 1000;
            q2.EquipmentPropertyName = "IPAP";
            q2.EquipmentPropertyValue = "My IPAP"; //not sure if we need this or if its the prescription property value

            EquipmentPropertyCx q3 = new EquipmentPropertyCx();
            q3.Id = 3;
            q3.EquipmentId = 1000;
            q3.EquipmentPropertyName = "Idle Time";
            q3.EquipmentPropertyValue = "My Idle Time !!"; //not sure if we need this or if its the prescription property value

            EquipProperties = EquipProperties.Append(q);
            EquipProperties = EquipProperties.Append(q2);
            EquipProperties = EquipProperties.Append(q3);

            await Task.Delay(100);
            return EquipProperties;
        }





    }
}
