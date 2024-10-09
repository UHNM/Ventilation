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
            
            q.Id = 100;
            q.DisplayName = "Mode";
            q.EquipmentId = 1000;
            q.Required = true;
            q.uiControlType = "TextBox";
            q.Type = "string";
            q.Order = 1;
         
            EquipmentPropertyCx q2 = new EquipmentPropertyCx();
            q2.Id = 101;
            q2.DisplayName = "Oxygen";
            q2.EquipmentId = 1000;
            q2.Required = true;
            q2.uiControlType = "TextBox";
            q2.Type = "int";
            q2.Order = 2;


            EquipmentPropertyCx q3 = new EquipmentPropertyCx();
            q3.Id = 102;
            q3.DisplayName = "Pressure";
            q3.EquipmentId = 1000;
            q3.Required = false;
            q3.uiControlType = "TextBox";
            q3.Type = "string";
            q3.Order = 3;

            EquipProperties = EquipProperties.Append(q);
            EquipProperties = EquipProperties.Append(q2);
            EquipProperties = EquipProperties.Append(q3);

            await Task.Delay(100);
            return EquipProperties;
        }





    }
}
