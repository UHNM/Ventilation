
using Domain.Entities.Complex;

namespace DAL.Repositories
{
    public interface IPatientListRepository
    {
        Task<IEnumerable<PatientListItemCx>> GetPatientList();
    }
}
