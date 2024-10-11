
using DAL.Contexts;
using Domain.Entities.Complex;

namespace DAL.Repositories.DefaultImplementations
{
    public class LoanRepository: Repository, ILoanRepository
    {

         public LoanRepository(IVentilationContext context)
           : base(context)
    {
    }

        public async Task<IEnumerable<PrescriptionCx>> GetPrescriptionsForALoan(int? loanId)
        {
            IEnumerable<PrescriptionCx> prescriptions = new List<PrescriptionCx>();

            PrescriptionCx p = new PrescriptionCx();
            p.Id = 1;
            p.EquipmentId = 1000;
            p.PrescriptionDate = new DateTime(2024, 09, 23);
            p.LoanId = loanId;
        
            PrescriptionCx p1 = new PrescriptionCx();
            p1.Id = 2;
            p1.EquipmentId = 2000;
            p1.PrescriptionDate = new DateTime(2024, 07, 23);
            p1.LoanId = loanId;
           

            prescriptions = prescriptions.Append(p);
            prescriptions = prescriptions.Append(p1);
            await Task.Delay(100);
            return prescriptions;
        }


        public async Task<IEnumerable<ConsumableCx>> GetConsumablesForALoan(int? loanId)
        {
            IEnumerable<ConsumableCx> consumables = new List<ConsumableCx>();

            ConsumableCx c = new ConsumableCx();
            c.Id = 1;
            c.EquipmentId = 1000;
            c.ConsumableDate = new DateTime(2024, 09, 23);
            c.LoanId = loanId;
            c.EquipmentName = "CPAP Face Mask";
            c.SupplierName = "Siemens";
            c.SerialNumber = "serial1";
            c.EquipmentType = "Mask";
            c.DeliveryMethod = "Courier";
            c.Comments = "I can add a comment to say that the courier was Royal Mail";
      
            ConsumableCx c1 = new ConsumableCx();
            c1.Id = 2;
            c1.EquipmentId = 1000;
            c1.ConsumableDate = new DateTime(2024, 07, 23);
            c1.LoanId = loanId;
            c1.EquipmentName = "Blue Tubing";
            c1.SupplierName = "phillips";
            c1.SerialNumber = "122345";
            c1.EquipmentType = "Tubing";
            c1.DeliveryMethod = "Post";
            c1.Comments = "sent to home address";

            ConsumableCx c2 = new ConsumableCx();
            c2.Id = 3;
            c2.EquipmentId = 1000;
            c2.ConsumableDate = new DateTime(2024, 07, 23);
            c2.LoanId = loanId;
            c2.EquipmentName = "Super Duper Filter";
            c2.SupplierName = "phillips";
            c2.SerialNumber = "465456456";
            c2.EquipmentType = "Filter";
            c2.DeliveryMethod = "Collected";
            c2.Comments = "ward staff will coolect, patient is taking home with them";

            consumables = consumables.Append(c);
            consumables = consumables.Append(c1);
            consumables = consumables.Append(c2);

            await Task.Delay(100);
            return consumables;
        }

    }
}
