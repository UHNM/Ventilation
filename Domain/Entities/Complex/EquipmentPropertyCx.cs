

namespace Domain.Entities.Complex
{
    public class EquipmentPropertyCx
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string? PropertyName { get; set; }
        public string? PropertyValue { get; set; }
    }
}
