using BAL.Managers;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;


namespace Ventilation.Components.Shared.StockComponents
{
    public partial class StockList
    {

        [Inject]
        IStockManager _stockManager { get; set; }

        [Inject]
        NavigationManager _navigationManager { get; set; }
       
        private IEnumerable<StockItem> stockListItems = default!;
        private HashSet<StockItem> selectedStockItem = new();


        protected override async Task OnInitializedAsync()
        {
      
            
        }

        private async Task<GridDataProviderResult<StockItem>> StockItemsDataProvider(GridDataProviderRequest<StockItem> request)
        {
            if (stockListItems is null) // pull employees only one time for client-side filtering, sorting, and paging
                stockListItems = await _stockManager.GetStockList();

            return await Task.FromResult(request.ApplyTo(stockListItems));
        }


        private Task OnSelectedItemsChanged(HashSet<StockItem> stockItems)
        {
            selectedStockItem = stockItems is not null && stockItems.Any() ? stockItems : new();
            return Task.CompletedTask;
        }

        private async Task OnRowClick(GridRowEventArgs<StockItem> args)
        {
            await Task.Delay(10);
            _navigationManager.NavigateTo("/stock/detail/" + args.Item.StockId);
            //await ModalService.ShowAsync(new ModalOption { Type = ModalType.Primary, Title = "Event: Row Click", Message = $"Id: {args.Item.Id}, Name: {args.Item.Name}" });
        }

    }
}