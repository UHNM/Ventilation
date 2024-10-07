using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.LoanComponents
{
    public partial class PrescriptionList
    {

        [Parameter]
        public List<Prescription>? paramPrescriptions { get; set; }

        [Parameter]
        public bool? paramIsEdit { get; set; }

    }
}