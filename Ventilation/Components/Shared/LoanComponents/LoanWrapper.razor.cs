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
        bool patientLoanCreated = false;
        Loan? loan = null;
        List<ToastMessage> messages = new List<ToastMessage>();

        protected override void OnInitialized()
        {
            stockItemSelected = null;
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
                patientLoanCreated = true;
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