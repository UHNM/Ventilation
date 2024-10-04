
namespace Domain.Models
{
    public class Loan : StockItem
    {
        public int? LoanId { get; set; }
        public int? PatientId { get; set; }
        public DateTime? LoanDate { get; set; }
    }
}
