namespace Domain.Models
{
    public class PrescriptionDetail
    {
        public int? PrescriptionId { get; set; }
        public int? LoanId { get; set; }
        public List<PrescriptionQuestion>? Questions { get; set; }
    }
}
