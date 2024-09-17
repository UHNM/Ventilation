using BAL.Managers;
using Microsoft.AspNetCore.Components.QuickGrid;


namespace Ventilation.Components.Pages
{
    public partial class Equipment
    {
        IQueryable<Models.Equipment>? equipment;
        PaginationState state = new PaginationState { ItemsPerPage = 5 };
        private readonly IEquipmentManager _equipmentManager;

        public Equipment(IEquipmentManager equipmentManager)
        {
            _equipmentManager = equipmentManager;
        }
      
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(500);

            var t = _equipmentManager.GetEquipmentList(); ;

            //List<Models.Equipment> items = new List<Models.Equipment>
            //{
            // new Models.Equipment(1, "Nippy 1000", 10, 20,true, new DateTime(2024, 3, 16), "Chris", DateTime.MinValue, null),
            // new Models.Equipment(2, "Shark 1234", 11, 23,true, new DateTime(2024, 7, 21), "Simon", DateTime.MinValue, null),
            // new Models.Equipment(3, "Some Mask", 12, 24,true, new DateTime(2024, 2, 10), "Nige", DateTime.MinValue, null),
            //};

            //equipment = (items).AsQueryable();

        }
    }
}