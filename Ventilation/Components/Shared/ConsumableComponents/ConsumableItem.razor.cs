using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.ConsumableComponents
{
    public partial class ConsumableItem
    {
        [Parameter]
        public Consumable? paramConsumable { get; set; }

        [Parameter]
        public bool? paramIsEdit { get; set; }

        [Parameter]
        public EventCallback<Consumable?> OnConsumableSelected { get; set; }

        private async Task OnEditConsumableClick()
        {
           await OnConsumableSelected.InvokeAsync(paramConsumable);
        }

    }
}