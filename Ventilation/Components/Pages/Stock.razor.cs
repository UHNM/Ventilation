using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Ventilation.Components.Shared.StockComponents;

namespace Ventilation.Components.Pages
{
    public partial class Stock
    {
        private Modal modal = default!;
        public bool? RefreshList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            RefreshList = false;
        }

        public async Task OnAddStockClick()
        {
            var parameters = new Dictionary<string, object>();
           
            parameters.Add("OnStockItemSaved", EventCallback.Factory.Create<EventArgs>(this, StockItemSaved));
            await modal.ShowAsync<AddStock>(title: "Add Stock", parameters: parameters);
        }

        private async Task OnHideModalClick()
        {
            await modal.HideAsync();
        }

        //Event callback from child component after saving the loan form
        protected async Task StockItemSaved()
        {
            //now close the Modal and refresh the underlying screen
            await modal.HideAsync();

            RefreshList = true;
            //doesn't refresh the stock list
            StateHasChanged();

        }
    }
}