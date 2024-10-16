

namespace Domain.Entities.Complex
{
    public class ConsumableDetailCx
    {
        public ConsumableCx Consumable                      { get; set; }
        public List<LookupCx>? DeliveryMethods              { get; set; }
        public List<EquipmentTypeCx>? EquipmentTypes        { get; set; }
        public List<EquipmentBaseCx>? EquipmentList         { get; set; }
    }
}
