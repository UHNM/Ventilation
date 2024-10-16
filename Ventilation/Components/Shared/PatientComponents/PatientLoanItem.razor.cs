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
        List<Consumable> loanConsumables = new();

        Tabs tabs = default!;
        private Modal modal = default!;

       

        protected override async Task OnInitializedAsync()
        {
            loanPrescriptions = await _loanManager.GetPrescriptionsForALoan(loan.LoanId);
            loanConsumables = await _loanManager.GetConsumablesForALoan(loan.LoanId);

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

        //Event callback from child component after saving the prescription form
        protected async Task OnPrescriptionListChanged(int? PrescriptionId)
        {
            if (PrescriptionId != null)
            {
                StateHasChanged();

                //user has updated or created a new prescription so refresh the data
                loanPrescriptions = await _loanManager.GetPrescriptionsForALoan(loan.LoanId);
            }

        }

        protected async Task OnConsumableListChanged(int? ConsumableId)
        {
            if (ConsumableId != null)
            {
                StateHasChanged();

                //user has updated or created a new consumable so refresh the data
                loanConsumables = await _loanManager.GetConsumablesForALoan(loan.LoanId);
            }

        }

    }
}