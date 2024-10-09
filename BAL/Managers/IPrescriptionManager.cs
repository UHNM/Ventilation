
using Domain.Models;

namespace BAL.Managers
{
    public interface IPrescriptionManager
    {
        Task<List<PrescriptionQuestion>> GetPrescriptionQuestions(int? equipmentId, int? prescriptionId);
    }
}
