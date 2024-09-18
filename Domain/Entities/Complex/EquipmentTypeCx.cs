namespace Domain.Entities.Complex
{
    public class EquipmentTypeCx
    {

        public int Id                           { get; set; }
        public string? EquipmentTypeName        { get; set; }
        public bool Available                   { get; set; }
        public DateTime CreatedDate             { get; set; }
        public string? CreatedBy                { get; set; }
        public DateTime? DeletedDate            { get; set; }
        public string? DeletedBy                { get; set; }
    }
}
