using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.PrescriptionComponents
{
    public partial class PrescriptionList
    {
        [Parameter]
        public Loan? paramLoan { get; set; }

        [CascadingParameter]
        public bool? UserClickedAdd { get; set; }

        [Parameter]
        public List<Prescription>? paramPrescriptions { get; set; }

        [Parameter]
        public bool? paramIsEdit { get; set; }

        [Parameter]
        public EventCallback<Prescription?> OnPrescriptionSelected { get; set; }

        Prescription? prescriptionSelected = new();

        [Inject]
        ILoanManager _loanManager { get; set; }

        //new grid stuff
        private IEnumerable<Prescription> prescriptionListItems = default!;


        protected override async Task OnInitializedAsync()
        {
            prescriptionSelected = null;
            await Task.Delay(100);

        }

        protected override async Task OnParametersSetAsync()
        {
            //after the user saves a prescription on the prescription form, refresh the data on prescription list
            var xx = paramLoan;
            var yy = "";
        }



        //new grid stuff
        private async Task<GridDataProviderResult<Prescription>> PrescriptionsDataProvider(GridDataProviderRequest<Prescription> request)
        {
            //TODO: might be able to move the get to here rather than param
            if (prescriptionListItems is null)
            {
                // prescriptionListItems = await _loanManager.GetPrescriptionsForALoan(paramLoan.LoanId);
                 prescriptionListItems = await _loanManager.GetPrescriptionsForALoan(paramLoan.LoanId);
            }

            return await Task.FromResult(request.ApplyTo(prescriptionListItems));
        }


        private async Task OnSelectPrescriptionClick(Prescription? item)
        {
            await Task.Delay(10);
           await OnPrescriptionSelected.InvokeAsync(item);
        }

    }
}