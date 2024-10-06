using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.LoanComponents
{
    public partial class AddLoan
    {
        [Parameter] public int PatientId { get; set; }

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
        protected async Task LoanIdChanged(Loan? Loan)
        {
            await Task.Delay(100);
            if (Loan != null)
            {
                loan = Loan;
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