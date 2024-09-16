namespace Models
{
    public class PatientLoan
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime DateOfLoan{ get; set; }
       
    }
}
