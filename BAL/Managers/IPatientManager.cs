
using Domain.Models;

namespace BAL.Managers
{
    public interface IPatientManager
    {
        PatientBase FindPatient(string hospitalNumber);

        Task<PatientBase> GetPatient(int internalPatientId);

        Task<PatientDetail> GetPatientDetail(int internalPatientId);
    }
}
