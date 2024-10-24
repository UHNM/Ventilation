using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace Ventilation.Components.Shared.FindComponents
{
    public partial class FindStock
    {
       public bool? RefreshList { get; set; }
      
        [Parameter]
        public EventCallback<StockItem?> OnStockSelected { get; set; }

        protected override async Task OnInitializedAsync()
        {
            RefreshList = false;
        }
     
        //Event callback from child component after saving additional information
        protected async Task StockSelected(StockItem? stock)
        {
            await Task.Delay(100);
            if (stock != null)
            {
                await OnStockSelected.InvokeAsync(stock);
            }

        }
    
    }





}