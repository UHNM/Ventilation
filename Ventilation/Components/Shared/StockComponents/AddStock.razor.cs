using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.StockComponents
{
    public partial class AddStock
    {
        StockItem? stockItemSelected = new();

        protected override async Task OnInitializedAsync()
        {
            stockItemSelected = null;
      
        }

        [Parameter]
        public EventCallback<EventArgs> OnStockItemSaved { get; set; }


        //Event callback from child component after saving additional information
        protected async Task EquipmentSelected(EquipmentBase? equipmentItem)
        {
            await Task.Delay(10);
            //passing in the equipment that was chosen but stock form wants a Stockitem so we can share the component with the Edit
            if (equipmentItem != null)
            {
                StockItem? s = new StockItem();
                s.EquipmentId = equipmentItem.EquipmentId;
                s.EquipmentName = equipmentItem.EquipmentName;
                s.EquipmentType = equipmentItem.EquipmentType;
                s.SerialNumber = equipmentItem.SerialNumber;
                s.SupplierName  = equipmentItem.SupplierName;
                s.EquipmentTypeId = equipmentItem.EquipmentTypeId;
                s.ServiceDate = null;
                s.StockId = null;
                s.ClinicalReference = null;
                stockItemSelected = s;
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