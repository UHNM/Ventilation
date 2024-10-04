using BAL.Managers;
using Domain.Entities.Complex;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Models;
using Ventilation.Components.Shared.AddLoan;

namespace Ventilation.Components.Shared
{
    public partial class PatientLoans
    {
        [Parameter]
        public int? PatientId { get; set; }

        [Inject]
        IPatientManager _patientManager { get; set; }
        List<Loan> patientLoans = new();
        AddLoanModal loanModal => new AddLoanModal();

        protected override async Task OnInitializedAsync()
        {
            patientLoans = await _patientManager.GetPatientLoans(PatientId);
            
        }


    
    }
}