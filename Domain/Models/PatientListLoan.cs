
using Domain.Entities.Complex;

namespace Domain.Models
{
    public class PatientListLoan
    {
        public List<PatientBase>? Patients { get; set; }
        public List<Loan>? PatientLoans { get; set; }
    }
}
