using Domain.Models;

namespace BAL.Managers
{
    public interface IPatientListManager
    {
        Task<List<PatientListItem>> GetPatientList();
    }
}
