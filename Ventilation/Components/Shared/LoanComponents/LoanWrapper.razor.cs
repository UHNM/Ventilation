using BAL.Managers;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.LoanComponents
{
    public partial class LoanWrapper
    {
        [Parameter] public int PatientId { get; set; }

        //if an edit we will have a loan object passed in, if a new loan, the object will be null
        [Parameter] public Loan? paramLoan { get; set; }


        StockItem? stockItemSelected = new();
        Tabs tabs = default!;
        bool hasLoanId = false;
        Loan? loan = null;
        List<ToastMessage> messages = new List<ToastMessage>();

        [Inject]
        ILoanManager _loanManager { get; set; }
        List<Prescription> loanPrescriptions = new();

        protected override async Task OnInitializedAsync()
        {
            stockItemSelected = null;

            //if we are passing a loan object in then we have an edit, otherwise an add
            if (paramLoan != null)
            {
                hasLoanId = true;
                loanPrescriptions = await _loanManager.GetPrescriptionsForALoan(paramLoan.LoanId);
                var xx = "";
            }

         
        }

        //Event callback from child component after saving additional information
        protected async Task StockSelected(StockItem? stock)
        {
            await Task.Delay(100);
            if (stock != null)
            {
                stockItemSelected = stock;
                StateHasChanged();
            }

        }

        //Event callback from child component after saving the loan form
        protected async Task LoanIdChanged(Loan? UpdateLoan)
        {
            if (UpdateLoan != null)
            {
                loan = UpdateLoan;
                loanPrescriptions = await _loanManager.GetPrescriptionsForALoan(loan.LoanId);
                hasLoanId = true;
                StateHasChanged();

                ShowMessage(ToastType.Success);
                await tabs.ShowTabByNameAsync("Prescriptions");
            }

        }


        private void ShowMessage(ToastType toastType) => messages.Add(CreateSaveMessage(toastType));

        private ToastMessage CreateSaveMessage(ToastType toastType)
    => new ToastMessage
    {
        Type = toastType,
        Message = $"Loan Successfully Created!",
    };

    }
}