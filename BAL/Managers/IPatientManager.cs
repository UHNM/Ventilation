
using Domain.Entities.Complex;
using Domain.Models;

namespace BAL.Managers
{
    public interface IPatientManager
    {
        PatientBase FindPatient(string hospitalNumber);

        Task<PatientBase> GetPatient(int internalPatientId);

        Task<PatientDetail> GetPatientDetail(int internalPatientId);

        Task<int> SavePatient(PatientDetail patient);

        Task<int> SavePatientLoan(Loan loan);

        Task<List<Loan>> GetPatientLoans(int? PatientId);
    }
}
