using Microsoft.AspNetCore.Components.QuickGrid;

namespace Ventilation.Components.Pages
{
    public partial class EquipmentType
    {
        IQueryable<Models.EquipmentType>? type;
        PaginationState state = new PaginationState { ItemsPerPage = 5 };


        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(500);
            List<Models.EquipmentType> items = new List<Models.EquipmentType>
            {
             new Models.EquipmentType(1, "Ventilator", 10, 20,true, new DateTime(2024, 1, 12), "Sue Whitfield", DateTime.MinValue, null),
             new Models.EquipmentType(2, "Face Mask", 11, 23,true, new DateTime(2024, 7, 21), "Dr Thomas", DateTime.MinValue, null),
            };

            type = (items).AsQueryable();

        }
    }
}