

namespace Domain.Models
{
    public class ConsumableDetail
    {
        public Consumable? ConsumableSummary { get; set; }
        public List<Domain.Models.LookUp>? DeliveryMethods { get; set; }
        public List<EquipmentType>? EquipmentTypes { get; set; }
        public List<EquipmentBase>? EquipmentList { get; set; }
    }
}
