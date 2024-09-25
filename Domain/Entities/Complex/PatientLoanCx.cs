
namespace Domain.Entities.Complex
{
    public class PatientLoanCx
    {
        public PatientBaseCx? Patient { get; set; }
        public List<StockItemCx>? Loans { get; set; }
    }
}
