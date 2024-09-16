
namespace Models
{
    public class EquipmentSupplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }

        public EquipmentSupplier(int id, string supplierName, DateTime createdDate, string? createdBy, DateTime deletedDate, string? deletedBy)
        {
            Id = id;
            SupplierName = supplierName;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            DeletedDate = deletedDate;
            DeletedBy = deletedBy;

        }
    }
}
