
namespace Models
{
    public class PatientDetail
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public bool HomeVisit { get; set; }
        public string? Diagnosis { get; set; }
        public string? SicknessScore { get; set; }
    }
}
