﻿namespace Domain.Entities.Complex
{
    public class LoanCx : StockItemCx
    {
        public int PatientId { get; set; }
        public DateTime LoanDate { get; set; }
       // public List<PrescriptionCx>? Prescriptions { get; set; }
    }
}