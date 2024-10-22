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
        public StockItem? stockItem { get; set; }

        [Inject]
        IStockManager _stockManager { get; set; }

        public StockItem? stockDetail = new();

        [Parameter]
        public EventCallback<int?> OnStockItemSaved { get; set; }

        protected override void OnInitialized()
        {
            stockDetail = stockItem;

            if(stockDetail.StockId == null)
            {
                //we are in an add
            }
            else
            {
                //we are at an update
            }
         
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