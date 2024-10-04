using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.AddLoan
{
    public partial class AddLoan
    {
        [Parameter] public int PatientId { get; set; }

        StockItem? stockItemSelected = new();

        protected override void OnInitialized()
        {
            stockItemSelected = null;
        }

        //Event callback from child component after saving additional information
        protected async Task StockSelected(StockItem? stock)
        {
            await Task.Delay(100);
            if (stock != null)
            {
                stockItemSelected = stock;
                StateHasChanged();
            }

        }

    }
}