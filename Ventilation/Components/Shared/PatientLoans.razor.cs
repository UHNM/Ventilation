using BAL.Managers;
using BlazorBootstrap;

using Domain.Models;
using Microsoft.AspNetCore.Components;
using Models;
using System.Diagnostics;
using Ventilation.Components.Shared.LoanComponents;

namespace Ventilation.Components.Shared
{
    public partial class PatientLoans
    {
        //[Parameter]
        //public int? PatientId { get; set; }

        [Parameter]
        public Domain.Models.PatientBase? Patient { get; set; }

        [Inject]
        IPatientManager _patientManager { get; set; }
        List<Loan> patientLoans = new();
   
        private Modal modal = default!;



        protected override async Task OnInitializedAsync()
        {
            patientLoans = await _patientManager.GetPatientLoans(Patient.Id);

            
        }

        private async Task OnAddLoanClick()
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("PatientId", Patient.Id);
            parameters.Add("paramLoan", null);

            await modal.ShowAsync<LoanWrapper>(title: "Add Loan for Patient: " + Patient.Surname + "," + Patient.Forename + " (" + Patient.HospitalNumber + ")", parameters: parameters);
        }

        private async Task OnHideModalClick()
        {
            await modal.HideAsync();
        }



    }
}