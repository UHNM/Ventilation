using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.QuickGrid;

namespace Ventilation.Components.Shared.FindComponents
{
    public partial class FindStock
    {
        //[Inject]
        //IStockManager _stockManager { get; set; }

     //   public StockToFind? stockToFind = new();
      //  List<StockItem> stockitemsFound = new();

        public bool? RefreshList { get; set; }
     
        
        //TODO: remove redundant code if Simon / Vent team are happy with the grid

        [Parameter]
        public EventCallback<StockItem?> OnStockSelected { get; set; }

        //IQueryable<StockItem>? stockList;

        // PaginationState state = new PaginationState { ItemsPerPage = 5 };

        protected override async Task OnInitializedAsync()
        {
            RefreshList = false;
        }


        //protected async Task OnFindClick(EditContext context)
        //{
        //    stockitemsFound = await _stockManager.FindStock(((StockToFind)context.Model).ClinicalTechRef);
        //    stockList = stockitemsFound.AsQueryable();


        //}

        //public class StockToFind
        //{
        //    public string? ClinicalTechRef { get; set; } = string.Empty;
        //}

        //Event callback from child component after saving additional information
        protected async Task StockSelected(StockItem? stock)
        {
            await Task.Delay(100);
            if (stock != null)
            {
                await OnStockSelected.InvokeAsync(stock);
            }

        }


        //private async Task SelectStockClick(StockItem item)
        //{


        //    await OnStockSelected.InvokeAsync(item);
        //}
    }





}