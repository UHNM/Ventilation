using BAL.Managers;
using Domain.Entities.Complex;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Models;

namespace Ventilation.Components.Shared.StockComponents
{
    public partial class StockForm
    {
        [Parameter]
        public EquipmentBase? equipmentItem { get; set; }

        [Inject]
        IStockManager _stockManager { get; set; }

        public StockItem? stockDetail = new();

        [Parameter]
        public EventCallback<int?> OnStockItemSaved { get; set; }

        protected override void OnInitialized()
        {
            stockDetail.EquipmentId = equipmentItem.EquipmentId;
            stockDetail.EquipmentName = equipmentItem.EquipmentName;
            stockDetail.SerialNumber = equipmentItem.SerialNumber;
            stockDetail.SupplierName = equipmentItem.SupplierName;
            stockDetail.EquipmentType = equipmentItem.EquipmentType;
            stockDetail.EquipmentTypeId = equipmentItem.EquipmentTypeId;
     

        }

        private async Task OnSaveStock(EditContext context)
        {
            await Task.Delay(10);
            int? Id = await _stockManager.SaveStockItem((StockItem)context.Model);

            //now close the Modal and refresh the underlying screen
            await OnStockItemSaved.InvokeAsync(Id);

        }

    }
}