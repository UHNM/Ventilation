namespace Models
{
    public class PatientStatus
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public bool Available  { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy1 { get; set; }

    }
}
