using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Models;

namespace Ventilation.Components.Shared.LoanComponents
{
    public partial class PrescriptionItem
    {
        [Parameter]
        public Prescription? paramPrescription { get; set; }

        [Parameter]
        public bool? paramIsEdit { get; set; }

        private async Task OnEditPrescriptionClick()
        {
            var xx = "";
        }

    }
}