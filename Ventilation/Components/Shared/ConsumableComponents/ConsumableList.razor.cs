using Domain.Models;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace Ventilation.Components.Shared.ConsumableComponents
{
    public partial class ConsumableList
    {
        [Parameter]
        public Loan? paramLoan { get; set; }

        [CascadingParameter]
        public bool? UserClickedAdd { get; set; }

        [Parameter]
        public List<Consumable>? paramConsumables { get; set; }

        [Parameter]
        public bool? paramIsEdit { get; set; }

        [Parameter]
        public EventCallback<Consumable?> OnConsumableSelected { get; set; }

        Consumable? consumableSelected = new();

        protected override async Task OnInitializedAsync()
        {
            consumableSelected = null;
            await Task.Delay(100);
        }

        //Event callback from child component after saving additional information
        protected async Task ConsumableSelected(Consumable? c)
        {
            consumableSelected = c;
            StateHasChanged();
            await OnConsumableSelected.InvokeAsync(c);


        }

    }
}