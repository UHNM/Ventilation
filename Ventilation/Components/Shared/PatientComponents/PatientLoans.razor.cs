using BAL.Managers;
using BlazorBootstrap;

using Domain.Models;
using Microsoft.AspNetCore.Components;
using Models;
using System.Diagnostics;
using Ventilation.Components.Shared.LoanComponents;

namespace Ventilation.Components.Shared.PatientComponents
{
    public partial class PatientLoans
    {
        [Parameter]
        public PatientBase? Patient { get; set; }

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
            parameters.Add("OnCancelLoan", EventCallback.Factory.Create<EventArgs>(this, OnHideModalClick));
            await modal.ShowAsync<LoanWrapper>(title: "Add Loan for Patient: " + Patient.Surname + "," + Patient.Forename + " (" + Patient.HospitalNumber + ")", parameters: parameters);
        }

        private async Task OnHideModalClick()
        {
            patientLoans = await _patientManager.GetPatientLoans(Patient.Id);
            await modal.HideAsync();

        }

        //Event callback from child component after saving the prescription form
        protected async Task LoanDataChanged()
        {
            patientLoans = await _patientManager.GetPatientLoans(Patient.Id);
            StateHasChanged();


        }



    }
}