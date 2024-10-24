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
      
       // List<Consumable> loanConsumables = new();

        Tabs tabs = default!;
        private Modal modal = default!;

        [Parameter]
        public EventCallback<EventArgs> OnLoanDataChanged { get; set; }


        protected override async Task OnInitializedAsync()
        {
          
          //  loanPrescriptions = await _loanManager.GetPrescriptionsForALoan(loan.LoanId);
         //   loanConsumables = await _loanManager.GetConsumablesForALoan(loan.LoanId);

        }

        private async Task OnEditLoanClick()
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("PatientId", loan.PatientId);
            parameters.Add("paramLoan", loan);
            parameters.Add("OnCancelLoan", EventCallback.Factory.Create<EventArgs>(this, OnHideModalClick));

            await modal.ShowAsync<LoanComponents.LoanWrapper>(title: "Edit Loan for Patient: " + Patient.Surname + "," + Patient.Forename + " (" + Patient.HospitalNumber + ")", parameters: parameters);
        }

        private async Task OnHideModalClick()
        {
            //pass a call back to patient loans as the data may have chnaged in the pop up and so needs refreshing on the page
            await OnLoanDataChanged.InvokeAsync();
            //  loanPrescriptions = await _loanManager.GetPrescriptionsForALoan(loan.LoanId);
            await modal.HideAsync();
        }

    
        //protected async Task OnConsumableListChanged(int? ConsumableId)
        //{
        //    if (ConsumableId != null)
        //    {
        //        StateHasChanged();

        //        //user has updated or created a new consumable so refresh the data
        //      //  loanConsumables = await _loanManager.GetConsumablesForALoan(loan.LoanId);
        //    }

        //}

    }
}