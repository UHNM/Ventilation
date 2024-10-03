
namespace Domain.Entities.Complex
{
    public class StockItemCx : EquipmentBaseCx
    {
        public int Id { get; set; }
        public string? ClinicalReference { get; set; }
        public DateTime ServiceDate { get; set; }

    }
}
