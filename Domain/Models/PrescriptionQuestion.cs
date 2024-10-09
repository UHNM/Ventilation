
namespace Domain.Models
{
    public class PrescriptionQuestion : EquipmentProperty
    {
     
        public int? ResponseInteger             { get; set; }
        public string? ResponseString           { get; set; }
        public bool? ResponseBool               { get; set; }
        public DateTime? ResponseDateTime       { get; set; }
    }
}
