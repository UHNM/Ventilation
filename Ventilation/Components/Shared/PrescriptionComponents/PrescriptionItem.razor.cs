using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.PrescriptionComponents
{
    public partial class PrescriptionItem
    {
        [Parameter]
        public Prescription? paramPrescription { get; set; }

        [Parameter]
        public bool? paramIsEdit { get; set; }

        [Parameter]
        public EventCallback<Prescription?> OnPrescriptionSelected { get; set; }

        private async Task OnEditPrescriptionClick()
        {
            await OnPrescriptionSelected.InvokeAsync(paramPrescription);
        }

    }
}