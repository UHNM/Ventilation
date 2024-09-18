namespace Domain.Entities.Complex
{
    public class EquipmentCx
    {

        public int Id                                 { get; set; }
        public string? EquipmentName                  { get; set; }
        public int SupplierId                         { get; set; }
        public int EquipmentTypeId                    { get; set; }
        public bool Available                         { get; set; }
        public DateTime CreatedDate                   { get; set; }
        public string? CreatedBy                      { get; set; }
        public DateTime? DeletedDate                  { get; set; }
        public string? DeletedBy                      { get; set; }
    }
}
