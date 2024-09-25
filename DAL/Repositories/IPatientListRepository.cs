
using Domain.Entities.Complex;

namespace DAL.Repositories
{
    public interface IPatientListRepository
    {
        IEnumerable<PatientLoanCx> GetPatientList();
    }
}
