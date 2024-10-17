namespace Domain.Models
{
    public class Consumable : EquipmentBase
    {
        public int? Id                          { get; set; }
        public DateTime ConsumableDate          { get; set; }
        public int? LoanId                      { get; set; }
        public int? DeliveryMethod              { get; set; }
        public string? DeliveryMethodName       { get; set; }
        public String? Comments                 { get; set; }
    }
}
