
using Domain.Entities.Complex;

namespace DAL.Repositories
{
    public interface IPatientRepository
    {
        PatientDetailCx FindPatient(string hospitalNumber);

    }
}
