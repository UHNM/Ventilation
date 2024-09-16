namespace Models
{
    public class EquipmentProperty
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string? PropertyName { get; set; }
        public string? PropertyValue { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }

    }
}
