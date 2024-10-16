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

        public bool? UserClickedAdd { get; set; }

        protected override async Task OnInitializedAsync()
        {
            loanConsumables = null;
            UserClickedAdd = false;

            var xx = paramLoan;
            if (paramLoan != null)
            {
                if (loanConsumables == null)
                {
                    loanConsumables = await _loanManager.GetConsumablesForALoan(paramLoan.LoanId);
                }
            }
        }

        private async Task OnAddConsumableClick()
        {
            await Task.Delay(100);
            UserClickedAdd = true;
        }

        protected async Task ConsumableSelected(Consumable? c)
        {
            await Task.Delay(100);
            StateHasChanged();
        }
    }
}