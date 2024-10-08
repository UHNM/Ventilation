
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
            p.PrescriptionDate = new DateTime(2024, 09, 23);
            p.LoanId = loanId;
            p.EquipmentId = 2000;

            PrescriptionCx p1 = new PrescriptionCx();
            p1.Id = 2;
            p1.PrescriptionDate = new DateTime(2024, 07, 23);
            p1.LoanId = loanId;
            p1.EquipmentId = 3000;

            prescriptions = prescriptions.Append(p);
            prescriptions = prescriptions.Append(p1);
            await Task.Delay(100);
            return prescriptions;
        }

    }
}
