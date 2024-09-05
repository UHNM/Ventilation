using Microsoft.AspNetCore.Components.QuickGrid;


namespace Ventilation.Components.Pages
{
    public partial class Equipment
    {

        IQueryable<Models.Equipment>? equipment;
        PaginationState state = new PaginationState { ItemsPerPage = 5 };


        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(500);
            List<Models.Equipment> items = new List<Models.Equipment>
            {
             new Models.Equipment(1, "Nippy 1000", 10, 20,true, new DateOnly(2024, 3, 16), "Chris"),
             new Models.Equipment(2, "Shark 1234", 11, 23,true, new DateOnly(2024, 7, 21), "Simon"),
             new Models.Equipment(3, "Some Mask", 12, 24,true, new DateOnly(2024, 2, 10), "Nige"),
            };

            equipment = (items).AsQueryable();

        }
    }
}