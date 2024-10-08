﻿
namespace Domain.Entities.Complex
{
    public class PatientBaseCx : PatientIdentityCx
    {
        public string? HospitalNumber { get; set; }
        public string? NHSNumber { get; set; }
        public string? Surname { get; set; }
        public string? Forename { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Address4 { get; set; }
        public string? PostCode { get; set; }
        public DateOnly? DateofBirth { get; set; }
        public string? Telephone1 { get; set; }
        public string? Telephone2 { get; set; }
        public string? CCG { get; set; }

    }
}
