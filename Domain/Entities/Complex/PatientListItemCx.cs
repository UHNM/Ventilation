
namespace Domain.Entities.Complex
{
    public class PatientListItemCx
    {
        public PatientBaseCx? Patient { get; set; }
        public List<LoanCx>? Loans { get; set; }
    }
}
