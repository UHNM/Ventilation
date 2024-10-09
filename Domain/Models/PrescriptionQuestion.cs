
namespace Domain.Models
{
    public class PrescriptionQuestion
    {
        public EquipmentProperty EquipmentProperty                  { get; set; }
        public int? PrescriptionQuestionResponseInteger             { get; set; }
        public string? PrescriptionQuestionResponseString           { get; set; }
        public bool? PrescriptionQuestionResponseBool               { get; set; }
        public DateTime? PrescriptionQuestionResponseDateTime       { get; set; }
    }
}
