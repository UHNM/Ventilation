
using Domain.Entities.Complex;
using Domain.Models;

namespace DAL.Repositories
{
    public interface IPatientRepository
    {
       PatientBaseCx FindPatient(string hospitalNumber);

       Task<PatientBaseCx> GetPatient(int internalPatientId);

       Task<PatientDetailCx> GetPatientDetail(int internalPatientId);

       Task<int> SavePatient(PatientDetail patient);

       Task<int> SavePatientLoan(Loan loan);

       Task<IEnumerable<LoanCx>> GetPatientLoans(int? PatientId);
      

    }
}
