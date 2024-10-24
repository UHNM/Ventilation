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
        [Parameter]
        public Loan? paramLoan { get; set; }

        StockItem? stockItemSelected = new();
        Tabs tabs = default!;
        public bool hasLoanId { get; set;}

        Loan? loan = null;
        List<ToastMessage> messages = new List<ToastMessage>();

        [Parameter]
        public EventCallback<EventArgs> OnCancelLoan { get; set; }


        public event EventHandler OnLoanChanged;

        protected override async Task OnInitializedAsync()
        {
            stockItemSelected = null;
            hasLoanId = false;
            //if we are passing a loan object in then we have an edit, otherwise an add
            if (paramLoan != null)
            {
                //show the extra tab for prescription and consumables
                hasLoanId = true;
               // loanPrescriptions = await _loanManager.GetPrescriptionsForALoan(paramLoan.LoanId);
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
                paramLoan = UpdateLoan;
                OnLoanChanged?.Invoke(this, EventArgs.Empty);
                hasLoanId = true;
                StateHasChanged();

                ShowMessage(ToastType.Success);
                await tabs.ShowTabByNameAsync("Prescriptions");
            }

        }

        //Event callback from child component after saving the loan form
        protected async Task CloseModal()
        {
            //let the parent component know to close the Modal
            await OnCancelLoan.InvokeAsync();

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