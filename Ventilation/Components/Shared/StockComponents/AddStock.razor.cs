using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.StockComponents
{
    public partial class AddStock
    {
        EquipmentBase? equipmentItemSelected = new();

        protected override async Task OnInitializedAsync()
        {
            equipmentItemSelected = null;
      
        }

        [Parameter]
        public EventCallback<EventArgs> OnStockItemSaved { get; set; }


        //Event callback from child component after saving additional information
        protected async Task EquipmentSelected(EquipmentBase? equipmentItem)
        {
            await Task.Delay(10);
            if (equipmentItem != null)
            {
                equipmentItemSelected = equipmentItem;
                StateHasChanged();
            }

        }

        //Event callback from child component after saving the loan form
        protected async Task StockItemSaved(int? StockItemId)
        {
            //pass the change back up the line to the stock page to close the modal and refresh the screen
            //now close the Modal and refresh the underlying screen
            await OnStockItemSaved.InvokeAsync();

        }

    }
}