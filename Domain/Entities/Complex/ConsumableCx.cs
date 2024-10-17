
namespace Domain.Entities.Complex
{
    public class ConsumableCx : EquipmentBaseCx
    {
        public int? Id { get; set; }
        public DateTime ConsumableDate { get; set; }
        public int? LoanId { get; set; }
        //TODO: Should the delivery method be populated from db lookup or enum?
        public int? DeliveryMethod { get; set; }
        public string? DeliveryMethodName { get; set; }
        public String? Comments { get; set; }
    }
}
