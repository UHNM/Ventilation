
namespace Domain.Entities.Complex
{
    public class PrescriptionPropertyCx : EquipmentPropertyCx
    {
        public int Id { get; set; }
        public string PrescriptionPropertyValueString { get; set; }
        public int PrescriptionPropertyValueInteger{ get; set; }
        public bool PrescriptionPropertyValueBool { get; set; }
        public int PrescriptionPropertyValueDateTime { get; set; }
    }
}
