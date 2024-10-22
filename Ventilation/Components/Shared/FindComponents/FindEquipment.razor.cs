using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Ventilation.Components.Shared.StockComponents;
using static Ventilation.Components.Shared.FindComponents.FindStock;
using Microsoft.AspNetCore.Components.QuickGrid;


namespace Ventilation.Components.Shared.FindComponents
{
   
    public partial class FindEquipment
    {

        [Inject]
        IEquipmentManager _equipmentManager { get; set; }

        public EquipmentToFind? equipmentToFind = new();
        List<EquipmentBase> equipmentItemsFound = new();
        IQueryable<EquipmentBase>? equipmentList;
        PaginationState state = new PaginationState { ItemsPerPage = 5 };

        protected async Task OnFindClick(EditContext context)
        {
           //  equipmentItemsFound = await _equipmentManager.FindEquipment(((EquipmentToFind)context.Model).EquipmentName);
             equipmentList = equipmentItemsFound.AsQueryable();
        }

        private async Task SelectEquipmentClick(EquipmentBase item)
        {
          
        }
    }

    public class EquipmentToFind
    {
        public string? EquipmentName { get; set; } = string.Empty;
    }
}