using BAL.Managers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace Ventilation.Components.Pages
{

    public partial class Equipment
    {
        [Inject]
        IEquipmentManager _equipmentManager { get; set;}


        IQueryable<Domain.Models.EquipmentDetails.Equipment>? equipment;
        PaginationState state = new PaginationState { ItemsPerPage = 5 };
      

      

        protected override void OnInitialized()
        {
            var items = _equipmentManager.GetEquipmentList(); ;
            equipment = (items).AsQueryable();

        }
    }
}