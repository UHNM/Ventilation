using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string? EquipmentTypeName { get; set; }
        public bool Available { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }

        public EquipmentType(int id, string? equipmentName, int supplierId, int equipmentTypeId, bool available, DateTime createdDate, string? createdBy, DateTime deletedDate, string? deletedBy)
        {
            Id = id;
            EquipmentTypeName = equipmentName;
            Available = available;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
            DeletedDate = deletedDate;
            DeletedBy = deletedBy;

        }
    }
}
