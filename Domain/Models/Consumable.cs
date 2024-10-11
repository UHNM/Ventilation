namespace Domain.Models
{
    public class Consumable : EquipmentBase
    {
        public int Id { get; set; }
        public DateTime ConsumableDate { get; set; }
        public int? LoanId { get; set; }
        public String? DeliveryMethod { get; set; }
        public String? Comments { get; set; }
    }
}
