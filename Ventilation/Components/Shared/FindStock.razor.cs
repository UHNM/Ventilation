using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace Ventilation.Components.Shared
{
    public partial class FindStock
    {
        [Inject]
        IStockManager _stockManager { get; set; }

        public StockToFind? stockToFind = new();
        List<StockItem> stockitemsFound = new();

        [Parameter]
        public EventCallback<StockItem?> OnStockSelected { get; set; }

        IQueryable<StockItem>? stockList;

        PaginationState state = new PaginationState { ItemsPerPage = 5 };

        protected async Task OnFindClick(EditContext context)
        {
            stockitemsFound = await _stockManager.FindStock(((StockToFind)context.Model).ClinicalTechRef);
            stockList =  stockitemsFound.AsQueryable();
          

        }

        public class StockToFind
        {
            public string? ClinicalTechRef { get; set; } = string.Empty;
        }

        private async Task SelectStockClick(StockItem item)
        {
           

            await OnStockSelected.InvokeAsync(item);
        }
    }





}