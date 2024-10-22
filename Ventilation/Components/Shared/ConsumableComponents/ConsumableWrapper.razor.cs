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

        //Event callback from child component after saving the consumable form
        protected async Task OnConsumableListChanged(int? ConsumableId)
        {
            if (ConsumableId != null)
            {
                StateHasChanged();

                //user has updated or created a new consumable so refresh the data...
                loanConsumables = await _loanManager.GetConsumablesForALoan(paramLoan.LoanId);
            }

        }
    }
}