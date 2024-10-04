
namespace Domain.Entities.Complex
{
    public class StockItemCx : EquipmentBaseCx
    {
        public int StockId { get; set; }
        public string? ClinicalReference { get; set; }
        public DateTime ServiceDate { get; set; }

    }
}
