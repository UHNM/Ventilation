
using Domain.Models;

namespace BAL.Managers
{
    public interface IPatientManager
    {
        PatientDetail FindPatient(string hospitalNumber);

        PatientDetail GetPatient(int internalPatientId);
    }
}
