using Domain.Entities.Complex;

namespace Domain.Models
{
    public class StockItem : EquipmentBase
    {
        public int? StockId { get; set; }
        public string? ClinicalReference { get; set; }
        public DateTime? ServiceDate { get; set; }


    }
}
