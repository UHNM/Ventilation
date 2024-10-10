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
            p.PrescriptionPropertyResponseBool = false; //inputcheckbox needs to handle null
            p.PrescriptionPropertyResponseInteger = null;
            p.PrescriptionPropertyResponseDateTime = null;

            PrescriptionPropertyCx p1 = new PrescriptionPropertyCx();
            p1.Id = 2;
            p1.EquipmentPropertyId = 101; //Oxygen Property
            p1.PrescriptionPropertyResponseString = null;
            p1.PrescriptionPropertyResponseBool = false; //inputcheckbox needs to handle null
            p1.PrescriptionPropertyResponseInteger = 80;
            p1.PrescriptionPropertyResponseDateTime = null;

            PrescriptionPropertyCx p2 = new PrescriptionPropertyCx();
            p2.Id = 3;
            p2.EquipmentPropertyId = 102; //Pressure Property
            p2.PrescriptionPropertyResponseString = null; // required for the property is false, no value was set
            p2.PrescriptionPropertyResponseBool = false; //inputcheckbox needs to handle null
            p2.PrescriptionPropertyResponseInteger = null;
            p2.PrescriptionPropertyResponseDateTime = null;

            PrescriptionPropertyCx p3 = new PrescriptionPropertyCx();
            p3.Id = 4;
            p3.EquipmentPropertyId = 103; //bool Property
            p3.PrescriptionPropertyResponseString = null;
            p3.PrescriptionPropertyResponseBool = true; //inputcheckbox needs to handle null
            p3.PrescriptionPropertyResponseInteger = null;
            p3.PrescriptionPropertyResponseDateTime = null;

            PrescriptionPropertyCx p4 = new PrescriptionPropertyCx();
            p4.Id = 5;
            p4.EquipmentPropertyId = 104; // drop down string Property
            p4.PrescriptionPropertyResponseString = "Compliance Level 2";
            p4.PrescriptionPropertyResponseBool = true; //inputcheckbox needs to handle null
            p4.PrescriptionPropertyResponseInteger = null;
            p4.PrescriptionPropertyResponseDateTime = null;

            PrescrProperties = PrescrProperties.Append(p);
            PrescrProperties = PrescrProperties.Append(p1);
            PrescrProperties = PrescrProperties.Append(p2);
            PrescrProperties = PrescrProperties.Append(p3);
            PrescrProperties = PrescrProperties.Append(p4);

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
            q.Options = null;

            EquipmentPropertyCx q2 = new EquipmentPropertyCx();
            q2.Id = 101;
            q2.DisplayName = "Oxygen";
            q2.EquipmentId = 1000;
            q2.Required = true;
            q2.uiControlType = "inputnumber";
            q2.Type = "int";
            q2.Order = 2;
            q2.Options = null;

            EquipmentPropertyCx q3 = new EquipmentPropertyCx();
            q3.Id = 102;
            q3.DisplayName = "Pressure";
            q3.EquipmentId = 1000;
            q3.Required = false;
            q3.uiControlType = "inputtext";
            q3.Type = "string";
            q3.Order = 3;
            q3.Options = null;

            EquipmentPropertyCx q4 = new EquipmentPropertyCx();
            q4.Id = 103;
            q4.DisplayName = "Some Check Box";
            q4.EquipmentId = 1000;
            q4.Required = false;
            q4.uiControlType = "inputcheckbox";
            q4.Type = "bool";
            q4.Order = 4;
            q4.Options = null;

            EquipmentPropertyCx q5 = new EquipmentPropertyCx();
            q5.Id = 104;
            q5.DisplayName = "Compliance";
            q5.EquipmentId = 1000;
            q5.Required = false;
            q5.uiControlType = "inputselect";
            q5.Type = "string";
            q5.Order = 5;
            
            List<EquipmentPropertyOptionCx> options = new List<EquipmentPropertyOptionCx>();
            
            EquipmentPropertyOptionCx o = new EquipmentPropertyOptionCx();
            o.EquipmentPropertyId = 104;
            o.Text = "Compliance Level 1";
            o.Value = "Compliance Level 1";
            o.Ordinal = 1;

            EquipmentPropertyOptionCx o1 = new EquipmentPropertyOptionCx();
            o1.EquipmentPropertyId = 104;
            o1.Text = "Compliance Level 2";
            o1.Value = "Compliance Level 2";
            o1.Ordinal = 2;

            EquipmentPropertyOptionCx o2 = new EquipmentPropertyOptionCx();
            o2.EquipmentPropertyId = 104;
            o2.Text = "Compliance Level 3";
            o2.Value = "Compliance Level 3";
            o2.Ordinal = 3;

            options.Add(o);
            options.Add(o1);
            options.Add(o2);
            q5.Options = options;



            EquipProperties = EquipProperties.Append(q);
            EquipProperties = EquipProperties.Append(q2);
            EquipProperties = EquipProperties.Append(q3);
            EquipProperties = EquipProperties.Append(q4);
            EquipProperties = EquipProperties.Append(q5);

            await Task.Delay(100);
            return await Task.FromResult(EquipProperties);
        }

    }
}
