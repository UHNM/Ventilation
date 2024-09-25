
using Domain.Entities.Complex;

namespace Domain.Models
{
    public class PatientLoan
    {
        public PatientBase? Patient { get; set; }
        public List<StockItem>? Loans { get; set; }
    }
}
