using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection;

namespace Ventilation.Components.Shared.PatientComponents
{
    public partial class PatientLoanItem
    {
        [Parameter]
        public Loan? loan { get; set; }


        [Parameter]
        public PatientBase? Patient { get; set; }

        [Inject]
        ILoanManager _loanManager { get; set; }
        List<Prescription> loanPrescriptions = new();

        Tabs tabs = default!;
        private Modal modal = default!;

       

        protected override async Task OnInitializedAsync()
        {
            loanPrescriptions = await _loanManager.GetPrescriptionsForALoan(loan.LoanId);


        }

        private async Task OnEditLoanClick()
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("PatientId", loan.PatientId);
            parameters.Add("paramLoan", loan);

            await modal.ShowAsync<LoanComponents.LoanWrapper>(title: "Edit Loan for Patient: " + Patient.Surname + "," + Patient.Forename + " (" + Patient.HospitalNumber + ")", parameters: parameters);
        }

        private async Task OnHideModalClick()
        {
            await modal.HideAsync();
        }

    }
}