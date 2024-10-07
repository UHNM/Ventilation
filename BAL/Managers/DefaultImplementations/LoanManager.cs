
using DAL.Repositories;
using Domain.Entities.Complex;
using Domain.Models;


namespace BAL.Managers.DefaultImplementations
{
    public class LoanManager : ILoanManager
    {
        private readonly ILoanRepository _dynamicResponseRepository;


        public LoanManager(ILoanRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }

        public async Task<List<Prescription>> GetPrescriptionsForALoan(int? loanId)
        {
            var dto = await _dynamicResponseRepository.GetPrescriptionsForALoan(loanId);
            return await Task.FromResult(GetPrescriptionFromDto(dto));
        }

        private static List<Prescription> GetPrescriptionFromDto(IEnumerable<PrescriptionCx> Dto)
        {
            if (Dto != null)
            {
                List<Prescription> prescriptions = new List<Prescription>();

                foreach (PrescriptionCx prescription in Dto)
                {
                    Prescription p  = new Prescription();
                    p.Id = prescription.Id;
                    p.LoanId    = prescription.LoanId;
                    p.PrescriptionDate = prescription.PrescriptionDate;
                    prescriptions.Add(p);
                }

                return prescriptions;
            }
            return null;
        }
    }
}
