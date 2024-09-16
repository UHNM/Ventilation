namespace Models
{
    public class Stock
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string? ClinicalReference { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime NextServiceDate { get; set; }

    }
}
