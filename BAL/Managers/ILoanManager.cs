
using Domain.Models;

namespace BAL.Managers
{
    public interface ILoanManager
    {
        Task<List<Prescription>> GetPrescriptionsForALoan(int? loanId);
    }
}
