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
        [Parameter]
        public Loan? paramLoan { get; set; }

        [Parameter]
        public Consumable? paramConsumable { get; set; }

        [Inject]
        IConsumableManager _consumableManager { get; set; }

        [Parameter]
        public EventCallback<int?> OnConsumableChanged { get; set; }

        List<ToastMessage> messages = new List<ToastMessage>();
        ConsumableDetail consumableDetail = new();
        Consumable? consumable = new Consumable();
        List<EquipmentType> typeOptions = new List<EquipmentType>();
        List<LookUp> deliveryOptions = new List<LookUp>();
        List<EquipmentBase>? equipOptions = new List<EquipmentBase>();
        List<EquipmentBase>? filteredEquipOptions = new List<EquipmentBase>();
        bool hasSelectedEquipmentType = false;


        //[Parameter]
        //public EventCallback<int?> OnConsumableChanged { get; set; }
        Dictionary<string, object> inputTextAreaAttributesComments = new Dictionary<string, object>();

        protected override async Task OnInitializedAsync()
        {
            //TODO: lots of validation on the consumables
            consumable = null;
            //TODO: remove all the task.Delays!!
            await Task.Delay(100);
            inputTextAreaAttributesComments.Add("rows", "4");
            inputTextAreaAttributesComments.Add("cols", "120");
          
            if (paramConsumable != null)
            {
                //if an edit, pass in the prescription id
                consumableDetail = await _consumableManager.GetConsumable(paramConsumable.Id, paramLoan.LoanId);
            }
            else
            {
                //if new then won't have a prescription so pass the equipment id from the loan and leave the prescription Id as null
                consumableDetail = await _consumableManager.GetConsumable(null, paramLoan.LoanId);
            }

            //TODO: Are we storing Lookup values as key or just the text???
            consumable = consumableDetail.ConsumableSummary;
            if (consumable.EquipmentTypeId > 0)
            {
                hasSelectedEquipmentType = true;
            }
            else
            {
                hasSelectedEquipmentType = false;
            }

            typeOptions = consumableDetail.EquipmentTypes;
            deliveryOptions = consumableDetail.DeliveryMethods;
            equipOptions = consumableDetail.EquipmentList;

            FilterEquipmentOptions();
        }



        private async Task OnSaveConsumable(EditContext context)
        {
       
            int? Id = await _consumableManager.SaveConsumable((Consumable)context.Model);

            //show Toast
            ShowMessage(ToastType.Success);

            await OnConsumableChanged.InvokeAsync(Id);

        }

        private void OnEquipmentTypeChange()
        {
            consumable.EquipmentId = 0;

            if (consumable.EquipmentTypeId > 0)
            {
                hasSelectedEquipmentType = true;
            }
            else
            {
                hasSelectedEquipmentType = false;
            }
            FilterEquipmentOptions();
           
        }

        private void FilterEquipmentOptions()
        {
                //TODO: Lamda expression for this??
                filteredEquipOptions.Clear();

                foreach (EquipmentBase item in equipOptions)
                {
                    if (item.EquipmentTypeId == consumable.EquipmentTypeId)
                    {
                        filteredEquipOptions.Add(item);
                    }
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