﻿
namespace Domain.Entities.Complex
{
    public class PatientLoanCx
    {
        public PatientBaseCx? Patient { get; set; }
        public List<LoanCx>? Loans { get; set; }
    }
}
