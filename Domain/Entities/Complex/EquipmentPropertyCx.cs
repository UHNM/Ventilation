

namespace Domain.Entities.Complex
{
    public class EquipmentPropertyCx
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string? EquipmentPropertyName { get; set; }
        public string? EquipmentPropertyValue { get; set; }
    }
}
