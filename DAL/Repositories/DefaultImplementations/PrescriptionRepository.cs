using DAL.Contexts;
using Domain.Entities.Complex;

namespace DAL.Repositories.DefaultImplementations
{
    public class PrescriptionRepository : Repository, IPrescriptionRepository
    {
        public PrescriptionRepository(IVentilationContext context)
           : base(context)
        {
        }

        public async Task<IEnumerable<PrescriptionPropertyCx>> GetPrescriptionResponses(int? prescriptionId)
        {
            IEnumerable<PrescriptionPropertyCx> PrescrProperties = new List<PrescriptionPropertyCx>();

            PrescriptionPropertyCx p = new PrescriptionPropertyCx();

            p.Id = 1;
            p.EquipmentPropertyId = 100; //Mode Property
            p.PrescriptionPropertyResponseString = "The Mode is set"; //we know the equipment property type is a string
            p.PrescriptionPropertyResponseBool = null;
            p.PrescriptionPropertyResponseInteger = null;
            p.PrescriptionPropertyResponseDateTime = null;

            PrescriptionPropertyCx p1 = new PrescriptionPropertyCx();
            p1.Id = 2;
            p1.EquipmentPropertyId = 101; //Oxygen Property
            p1.PrescriptionPropertyResponseString = null;
            p1.PrescriptionPropertyResponseBool = null;
            p1.PrescriptionPropertyResponseInteger = 80;
            p1.PrescriptionPropertyResponseDateTime = null;

            PrescriptionPropertyCx p2 = new PrescriptionPropertyCx();
            p2.Id = 3;
            p2.EquipmentPropertyId = 102; //Pressure Property
            p2.PrescriptionPropertyResponseString = null; // required for the property is false, no value was set
            p2.PrescriptionPropertyResponseBool = null;
            p2.PrescriptionPropertyResponseInteger = null;
            p2.PrescriptionPropertyResponseDateTime = null;

            PrescrProperties = PrescrProperties.Append(p);
            PrescrProperties = PrescrProperties.Append(p1);
            PrescrProperties = PrescrProperties.Append(p2);

            await Task.Delay(100);
            return await Task.FromResult(PrescrProperties);
        }

        public async Task<IEnumerable<EquipmentPropertyCx>> GetPrescriptionEquipmentProperties(int? equipmentId)
        {
            IEnumerable<EquipmentPropertyCx> EquipProperties = new List<EquipmentPropertyCx>();

            EquipmentPropertyCx q = new EquipmentPropertyCx();

            q.Id = 100;
            q.DisplayName = "Mode";
            q.EquipmentId = 1000;
            q.Required = true;
            q.uiControlType = "inputtext";
            q.Type = "string";
            q.Order = 1;

            EquipmentPropertyCx q2 = new EquipmentPropertyCx();
            q2.Id = 101;
            q2.DisplayName = "Oxygen";
            q2.EquipmentId = 1000;
            q2.Required = true;
            q2.uiControlType = "inputnumber";
            q2.Type = "int";
            q2.Order = 2;


            EquipmentPropertyCx q3 = new EquipmentPropertyCx();
            q3.Id = 102;
            q3.DisplayName = "Pressure";
            q3.EquipmentId = 1000;
            q3.Required = false;
            q3.uiControlType = "inputtext";
            q3.Type = "string";
            q3.Order = 3;

            EquipProperties = EquipProperties.Append(q);
            EquipProperties = EquipProperties.Append(q2);
            EquipProperties = EquipProperties.Append(q3);

            await Task.Delay(100);
            return await Task.FromResult(EquipProperties);
        }

    }
}
