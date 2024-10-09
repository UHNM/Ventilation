using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.LoanComponents
{
    public partial class PrescriptionList
    {
        [CascadingParameter]
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

        protected override async Task OnInitializedAsync()
        {
            prescriptionSelected = null;
            
        }


        protected override async Task OnParametersSetAsync()
        {
            
        }

        //Event callback from child component after saving additional information
        protected async Task PrescriptionSelected(Prescription? p)
        {
            prescriptionSelected = p;
            StateHasChanged();
            await OnPrescriptionSelected.InvokeAsync(p);
           

        }

        

    }
}