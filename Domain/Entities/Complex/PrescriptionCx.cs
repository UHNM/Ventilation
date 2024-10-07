
namespace Domain.Entities.Complex
{
    public class PrescriptionCx
    {
        public int Id { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public int? LoanId { get; set; }
       // public List<PrescriptionPropertyCx>? PrescriptionProperties { get; set; }

    }
}
