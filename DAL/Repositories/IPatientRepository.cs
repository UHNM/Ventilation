
using Domain.Entities.Complex;

namespace DAL.Repositories
{
    public interface IPatientRepository
    {
        PatientBaseCx FindPatient(string hospitalNumber);

       Task<PatientBaseCx> GetPatient(int internalPatientId);

        Task<PatientDetailCx> GetPatientDetail(int internalPatientId);

      

    }
}
