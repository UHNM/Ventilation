using BAL.Managers;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;


using BlazorBootstrap;

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


        //private Task OnSelectedItemsChanged(HashSet<StockItem> stockItems)
        //{
        //    selectedStockItem = stockItems is not null && stockItems.Any() ? stockItems : new();
        //    return Task.CompletedTask;
        //}

        //private async Task OnRowClick(GridRowEventArgs<StockItem> args)
        //{
        //    await Task.Delay(10);
        //    _navigationManager.NavigateTo("/stock/detail/" + args.Item.StockId);
        //}

    }
}