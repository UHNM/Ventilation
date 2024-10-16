using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

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

        [Parameter]
        public EventCallback<int?> OnConsumableChanged { get; set; }

        List<ToastMessage> messages = new List<ToastMessage>();
        Consumable consumableDetail = new();

        //[Parameter]
        //public EventCallback<int?> OnConsumableChanged { get; set; }
        Dictionary<string, object> inputTextAreaAttributesComments = new Dictionary<string, object>();

        protected override async Task OnInitializedAsync()
        {
            //TODO: remove all the task.Delays!!
            await Task.Delay(100);
            inputTextAreaAttributesComments.Add("rows", "4");
            inputTextAreaAttributesComments.Add("cols", "120");



            if (paramConsumable != null)
            {
                //if an edit, pass in the prescription id
                consumableDetail = await _consumableManager.GetConsumable(paramConsumable.Id);
               
            }
            else
            {
                //if new then won't have a prescription so pass the equipment id from the loan and leave the prescription Id as null
              //  detail = await _prescriptionManager.GetPrescriptionQuestions(paramLoan.EquipmentId, null, paramLoan.LoanId);
            }
        }



        private async Task OnSaveConsumable(EditContext context)
        {
            Task.Delay(100);

           

            int? Id = await _consumableManager.SaveConsumable((Consumable)context.Model);

         
            await OnConsumableChanged.InvokeAsync(Id);

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