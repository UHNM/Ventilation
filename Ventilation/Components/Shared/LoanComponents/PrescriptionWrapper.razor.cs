using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.LoanComponents
{
    public partial class PrescriptionWrapper
    {
        [CascadingParameter]
        public Loan? paramLoan { get; set; }
        
        //[CascadingParameter]
        //public bool? hasLoanId { get; set; }

        [Inject]
        ILoanManager _loanManager { get; set; }
        List<Prescription> loanPrescriptions = new();

        protected override async Task OnInitializedAsync()
        {
            loanPrescriptions = null;


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
        }

    }
}