﻿
using Domain.Entities.Complex;

namespace DAL.Repositories
{
    public interface ILoanRepository
    {
        Task<IEnumerable<PrescriptionCx>> GetPrescriptionsForALoan(int? loanId);

        Task<IEnumerable<ConsumableCx>> GetConsumablesForALoan(int? loanId);
    }
}
