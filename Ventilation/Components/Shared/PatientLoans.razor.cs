using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Models;

namespace Ventilation.Components.Shared
{
    public partial class PatientLoans
    {
        [Parameter]
        public int? PatientId { get; set; }

        [Inject]
        IPatientManager _patientManager { get; set; }
        List<Loan> loans = new();


        protected override async Task OnInitializedAsync()
        {
            loans = await _patientManager.GetPatientLoans(PatientId);
        }


    
    }
}