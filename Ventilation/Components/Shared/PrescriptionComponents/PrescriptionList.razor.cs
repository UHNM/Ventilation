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

        [Parameter]
        public EventCallback<int?> OnPrescriptionListChanged { get; set; }

        Prescription? prescriptionSelected = new();

        protected override async Task OnInitializedAsync()
        {
            prescriptionSelected = null;
            await Task.Delay(100);

        }

        //Event callback from child component after saving additional information
        protected async Task PrescriptionSelected(Prescription? p)
        {
            prescriptionSelected = p;
            StateHasChanged();
            await OnPrescriptionSelected.InvokeAsync(p);


        }

        //Event callback from child component after saving the prescription form
        protected async Task OnPrescriptionChanged(int? PrescriptionId)
        {
            if (PrescriptionId != null)
            {
                StateHasChanged();
                //let the parent component know to refresh the prescription lisr
                await OnPrescriptionListChanged.InvokeAsync(PrescriptionId);
            }

        }



    }
}