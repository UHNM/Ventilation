using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.LoanComponents
{
    public partial class PrescriptionWrapper
    {
        [CascadingParameter]
        public Loan? paramLoan { get; set; }
        
       
        public bool? AddPrescription { get; set; }

        [Inject]
        ILoanManager _loanManager { get; set; }
        List<Prescription> loanPrescriptions = new();

        public bool? UserClickedAdd { get; set; }

        protected override async Task OnInitializedAsync()
        {
            loanPrescriptions = null;
            UserClickedAdd = false;

            var xx = paramLoan;
        }

        protected override async Task OnParametersSetAsync()
        {
            //cascading parameter from parent
            //if an edit we will have a loanId in the initial paramLoan
            //If an Add we won't have a loanId until after the user has saved the item, this is why code is in paramSet
            if (paramLoan != null)
            {
                if (loanPrescriptions == null)
                {
                    loanPrescriptions = await _loanManager.GetPrescriptionsForALoan(paramLoan.LoanId);
                }
            }
            await base.OnParametersSetAsync();
        }


        private async Task OnAddPrescriptionClick()
        {
            await Task.Delay(100);
            UserClickedAdd = true;
        }

        protected async Task PrescriptionSelected(Prescription? p)
        {
            await Task.Delay(100);

            StateHasChanged();
           


        }

    }
}