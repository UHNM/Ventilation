﻿namespace Domain.Models
{
    public class StockItem
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string? EquipmentName { get; set; }
        public string? SerialNumber { get; set; }
        public string? ClinicalReference { get; set; }
        public DateTime LoanDate { get; set; }
    }
}