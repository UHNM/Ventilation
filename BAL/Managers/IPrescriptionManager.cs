
using Domain.Models;

namespace BAL.Managers
{
    public interface IPrescriptionManager
    {
        Task<PrescriptionDetail> GetPrescriptionQuestions(int? equipmentId, int? prescriptionId, int? loanId);
        Task<int> SavePrescription(PrescriptionDetail prescription);
    }
}
