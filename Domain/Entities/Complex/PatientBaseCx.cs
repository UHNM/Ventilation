
namespace Domain.Entities.Complex
{
    public class PatientBaseCx
    {
        public int? Id { get; set; }
        public int? InternalPatientId { get; set; }
        public string? HospitalNumber { get; set; }
        public string? NHSNumber { get; set; }
        public string? Surname { get; set; }
        public string? Forename { get; set; }
    }
}
