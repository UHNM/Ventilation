﻿
namespace Domain.Entities.Complex
{
    public class PatientDetailCx : PatientBaseCx
    {
        public DateTime? DischargeDate { get; set; }
        public DateTime? DateInitiated { get; set; }
        public int? PatientStatus { get; set; }
        public int? DischargeStatus { get; set; }
        public string? CCG { get; set; }
        public string? Diagnosis { get; set; }
        public int? Dependency { get; set; }
        public bool Tracheostomy { get; set; }
        public bool HomeVisit { get; set; }
        public bool HomeService { get; set; }
        public int? SmokingStatus { get; set; }
        public DateTime? PegDate { get; set; }
        public string? Comments { get; set; }
    }
}