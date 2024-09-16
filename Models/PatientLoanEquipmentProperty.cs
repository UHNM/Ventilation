
namespace Models
{
    public class PatientLoanEquipmentProperty
    {
        public int Id { get; set; }
        public int PatientLoanId { get; set; }
        public int PatientLoanPatientId { get; set; }
        public int PatientLoanEquipmentId { get; set; }
        public int EquipmentPropertyId { get; set; }
        public string? EquipmentPropertyValue { get; set; }
    }
}
