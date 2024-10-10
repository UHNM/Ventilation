using Domain.Entities.Complex;

namespace Domain.Models
{
    public class EquipmentProperty
    {
        public int Id                                 { get; set; }
        public int EquipmentId                        { get; set; }
        public bool Required                          { get; set; }
        public string? uiControlType                  { get; set; }
        public string? Type                           { get; set; }
        public int Order                              { get; set; }
        public string? DisplayName                    { get; set; }
        public List<PropertyOption>? Options          { get; set; }
    }
}
