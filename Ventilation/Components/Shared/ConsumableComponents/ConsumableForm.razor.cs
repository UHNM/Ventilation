using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.ConsumableComponents
{
    public partial class ConsumableForm
    {
        [CascadingParameter]
        public Loan? paramLoan { get; set; }

        [Parameter]
        public Consumable? paramConsumable { get; set; }

        [Inject]
        IConsumableManager _consumableManager { get; set; }

        List<ToastMessage> messages = new List<ToastMessage>();
        // PrescriptionDetail detail = new();

        //[Parameter]
        //public EventCallback<int?> OnConsumableChanged { get; set; }


        protected override async Task OnInitializedAsync()
        {
            //TODO: remove all the task.Delays!!
            await Task.Delay(100);
            var xx = paramConsumable;
            var yy = paramLoan;


            if (paramConsumable != null)
            {
                //if an edit, pass in the prescription id
               // detail = await _prescriptionManager.GetPrescriptionQuestions(paramPrescription.EquipmentId, paramPrescription.Id, paramLoan.LoanId);
               
            }
            else
            {
                //if new then won't have a prescription so pass the equipment id from the loan and leave the prescription Id as null
              //  detail = await _prescriptionManager.GetPrescriptionQuestions(paramLoan.EquipmentId, null, paramLoan.LoanId);
            }
        }


        private void ShowMessage(ToastType toastType) => messages.Add(CreateSaveMessage(toastType));

        private ToastMessage CreateSaveMessage(ToastType toastType)
    => new ToastMessage
    {
        Type = toastType,
        Message = $"Consumable Saved!",
    }
    ;
    }
}