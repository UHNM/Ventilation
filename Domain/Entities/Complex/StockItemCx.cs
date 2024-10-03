
namespace Domain.Entities.Complex
{
    public class StockItemCx
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string? EquipmentName { get; set; }
        public string? EquipmentType { get; set; }
        public string? SerialNumber { get; set; }
        public string? ClinicalReference { get; set; }
        public DateTime ServiceDate { get; set; }

    }
}
