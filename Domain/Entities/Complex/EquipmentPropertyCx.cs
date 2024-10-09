

namespace Domain.Entities.Complex
{
    public class EquipmentPropertyCx
    {
        public int Id                           { get; set; }
        public int EquipmentId                  { get; set; }
        public bool Required                    { get; set; }
        public string? uiControlType            { get; set; }
        public string? Type                     { get; set; }
        public int Order                        { get; set; }
        public string? DisplayName              { get; set; }

        //public int Values { get; set; } array of lookup 

    }
}
