using BAL.Managers;
using BlazorBootstrap;
using Domain.Entities.Complex;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Models;
using Ventilation.Components.Shared.LoanFolder;

namespace Ventilation.Components.Shared
{
    public partial class PatientLoans
    {
        [Parameter]
        public int? PatientId { get; set; }

        [Inject]
        IPatientManager _patientManager { get; set; }
        List<Loan> patientLoans = new();
       // AddLoanModal loanModal => new AddLoanModal();
        private Modal modal = default!;



        protected override async Task OnInitializedAsync()
        {
            patientLoans = await _patientManager.GetPatientLoans(PatientId);
            
        }

        private async Task OnAddLoanClick()
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("PatientId", PatientId);
      
            await modal.ShowAsync<Ventilation.Components.Shared.LoanFolder.AddLoan>(title: "Add Loan for Patient: " + PatientId, parameters: parameters);
        }

        private async Task OnHideModalClick()
        {
            await modal.HideAsync();
        }



    }
}