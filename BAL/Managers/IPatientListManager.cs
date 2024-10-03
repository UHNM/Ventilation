using Domain.Models;

namespace BAL.Managers
{
    public interface IPatientListManager
    {
        List<PatientListItem> GetPatientList();
    }
}
