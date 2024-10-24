using BAL.Managers;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.StockComponents
{
    public partial class StockList
    {
        [CascadingParameter]
        public bool? RefreshList { get; set; }

       

        [Inject]
        IStockManager _stockManager { get; set; }

        [Inject]
        NavigationManager _navigationManager { get; set; }
       
        private IEnumerable<StockItem> stockListItems = default!;
        private HashSet<StockItem> selectedStockItem = new();

        [Parameter]
        public EventCallback<StockItem?> OnStockSelected { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            //TODO: needs to be async due to component base, require further investigation
            if(RefreshList == true)
            {
                stockListItems = await _stockManager.GetStockList();
            }
        }

        private async Task<GridDataProviderResult<StockItem>> StockItemsDataProvider(GridDataProviderRequest<StockItem> request)
        {
           
            if (stockListItems is null) 
                stockListItems = await _stockManager.GetStockList();

            return await Task.FromResult(request.ApplyTo(stockListItems));
        }

        private async Task OnSelectStockClick(StockItem? item)
        {
           await OnStockSelected.InvokeAsync(item);
        }

     
    }
}