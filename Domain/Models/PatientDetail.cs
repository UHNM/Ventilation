namespace Domain.Models
{
    public class PatientDetail : PatientIdentity
    {
        public DateTime? DischargeDate { get; set; }
        public DateTime? DateInitiated { get; set; }
        public int? PatientStatus { get; set; }
        public int? DischargeStatus { get; set; }
        public string? CCG { get; set; }
        public int? DiagnosisCategory { get; set; }
        public int? DiagnosisSubCategory { get; set; }
        public string? DiagnosisOther { get; set; }
        public int? Dependency { get; set; }
        public bool Tracheostomy { get; set; }
        public bool HomeVisit { get; set; }
        public bool HomeService { get; set; }
        public int? SmokingStatus { get; set; }
        public DateTime? PegDate { get; set; }
        public string? Comments { get; set; }
        public DateTime? FundingStartDate { get; set; }
        public bool LoneWorker { get; set; }
    }
}
