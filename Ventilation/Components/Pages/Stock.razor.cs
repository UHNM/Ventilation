using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Ventilation.Components.Shared.StockComponents;

namespace Ventilation.Components.Pages
{
    public partial class Stock
    {
        private Modal modal = default!;


        protected override async Task OnInitializedAsync()
        {
        }

        public async Task OnAddStockClick()
        {
            await modal.ShowAsync<AddStock>(title: "Add Stock");
        }

        private async Task OnHideModalClick()
        {
            await modal.HideAsync();
        }
    }
}