using Microsoft.AspNetCore.Components;


namespace Ventilation.Components.Pages
{
    public partial class StockDetail
    {
        [Parameter]
        public int StockId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(10);

        }

    }
}