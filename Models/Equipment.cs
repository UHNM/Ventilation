namespace Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string? EquipmentName { get; set; }
        public int SupplierId { get; set; }
        public int EquipmentTypeId { get; set; }
        public bool Available { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }

        public Equipment(int id, string? equipmentName, int supplierId, int equipmentTypeId, bool available, DateTime createdDate, string? createdBy, DateTime deletedDate, string? deletedBy)
        {
            Id = id;
            EquipmentName = equipmentName;
            SupplierId = supplierId;
            EquipmentTypeId = equipmentTypeId;
            Available = available;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            DeletedDate = deletedDate;
            DeletedBy = deletedBy;

        }
    }
}
