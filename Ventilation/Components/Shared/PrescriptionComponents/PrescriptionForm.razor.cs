using BAL.Managers;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Ventilation.Components.Shared.PrescriptionComponents
{
    public partial class PrescriptionForm
    {
        [Parameter]
        public Loan? paramLoan { get; set; }

        [Parameter]
        public Prescription? paramPrescription { get; set; }

        [Inject]
        IPrescriptionManager _prescriptionManager { get; set; }

        List<ToastMessage> messages = new List<ToastMessage>();
        PrescriptionDetail detail = new();

        [Parameter]
        public EventCallback<EventArgs> OnPrescriptionChanged { get; set; }

        //to delete
        //public Loan? loanDetail = new();

        protected override async Task OnInitializedAsync()
        {

            if (paramPrescription != null)
            {
                //if an edit, pass in the prescription id
                detail = await _prescriptionManager.GetPrescriptionQuestions(paramPrescription.EquipmentId, paramPrescription.Id, paramLoan.LoanId);

            }
            else
            {
                //if new then won't have a prescription so pass the equipment id from the loan and leave the prescription Id as null
                detail = await _prescriptionManager.GetPrescriptionQuestions(paramLoan.EquipmentId, null, paramLoan.LoanId);
            }
        }

        private async Task OnSavePrescription(EditContext context)
        {
            //save the prescription
            int? Id = await _prescriptionManager.SavePrescription((PrescriptionDetail)context.Model);

            //show Toast
            ShowMessage(ToastType.Success);

            //let the parent component know to refresh the prescription list
            await OnPrescriptionChanged.InvokeAsync();

        }

        private async Task OnCancelPrescriptionClick()
        {
            //let the parent component know to refresh the prescription list
            await OnPrescriptionChanged.InvokeAsync();
        }

        private void ShowMessage(ToastType toastType) => messages.Add(CreateSaveMessage(toastType));

        private ToastMessage CreateSaveMessage(ToastType toastType)
    => new ToastMessage
    {
        Type = toastType,
        Message = $"Prescription Saved!",
    }
    ;


    }
}