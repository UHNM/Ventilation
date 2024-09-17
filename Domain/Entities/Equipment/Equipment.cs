using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Equipment
{
    [Table("Equipment.Equipment")]
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string? EquipmentName { get; set; }
        
    }
}
