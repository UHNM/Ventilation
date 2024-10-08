﻿
namespace Domain.Models
{
    public class PrescriptionProperty
    {
        public int Id { get; set; }
        public int? EquipmentPropertyId { get; set; }
        public string? PrescriptionPropertyResponseString { get; set; }
        public int? PrescriptionPropertyResponseInteger { get; set; }
        //TODO: should be passing nullable value, need to work out how inputcheckbox handles that
        public bool PrescriptionPropertyResponseBool { get; set; }
        public DateTime? PrescriptionPropertyResponseDateTime { get; set; }
    }
}
