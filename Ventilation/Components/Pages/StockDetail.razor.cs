using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;


namespace Ventilation.Components.Pages
{
    public partial class StockDetail
    {
        [Parameter]
        public int StockId { get; set; }

        [Inject]
        IStockManager _stockManager { get; set; }

        StockItem stockItem = new();

        [Inject]
        NavigationManager _navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {

            stockItem = await _stockManager.GetStockItem(StockId);
           
        }

        //Event callback from child component after saving the loan form
        protected async Task StockItemSaved(int? StockItemId)
        {
            await Task.Delay(10);
            _navigationManager.NavigateTo("/stock");


        }

    }
}