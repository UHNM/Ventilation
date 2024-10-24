using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.ConsumableComponents
{
    public partial class ConsumableWrapper
    {
        [Parameter]
        public Loan? paramLoan { get; set; }


        public bool? AddConsumable { get; set; }

        [Inject]
        ILoanManager _loanManager { get; set; }
        List<Consumable> loanConsumables = new();

        Consumable? consumableSelected = new();

        public bool? UserClickedAdd { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(10);
            var cc = consumableSelected;
            UserClickedAdd = false;
        }

        private async Task OnAddConsumableClick()
        {
            await Task.Delay(10);
            UserClickedAdd = true;
        }

        protected async Task ConsumableSelected(Consumable? c)
        {
            consumableSelected = c;
            await Task.Delay(10);
            StateHasChanged();
        }

        //Event callback from child component after saving the prescription form
        protected async Task OnConsumableChanged()
        {
            UserClickedAdd = false;
            consumableSelected = new();
            StateHasChanged();


        }
      
    }
}