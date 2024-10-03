namespace Domain.Models
{
    public class PatientListItem
    {
        public PatientBase? Patient { get; set; }
        public List<Loan>? Loans { get; set; }
    }
}
