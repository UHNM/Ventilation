using BAL.Managers;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.ConsumableComponents
{
    public partial class ConsumableList
    {
        [Parameter]
        public Loan? paramLoan { get; set; }

        [CascadingParameter]
        public bool? UserClickedAdd { get; set; }

        //[Parameter]
        //public List<Consumable>? paramConsumables { get; set; }

        [Parameter]
        public bool? paramIsEdit { get; set; }

        [Parameter]
        public EventCallback<Consumable?> OnConsumableSelected { get; set; }

        [Parameter]
        public EventCallback<int?> OnConsumableListChanged { get; set; }

      //  Consumable? consumableSelected = new();

        //new grid stuff
        private IEnumerable<Consumable> consumableListItems = default!;

        [Inject]
        ILoanManager _loanManager { get; set; }
       
        protected override async Task OnInitializedAsync()
        {
          //  consumableSelected = null;
            await Task.Delay(100);
        }

        //Event callback from child component after saving additional information
        protected async Task ConsumableSelected(Consumable? c)
        {
          //  consumableSelected = c;
            StateHasChanged();
            await OnConsumableSelected.InvokeAsync(c);


        }

        //Event callback from child component after saving the prescription form
        protected async Task OnConsumableChanged(int? ConsumableId)
        {
            if (ConsumableId != null)
            {
                StateHasChanged();

                //let the parent component know to refresh the prescription lisr
                await OnConsumableListChanged.InvokeAsync(ConsumableId);
            }

        }






        //new grid stuff
        private async Task<GridDataProviderResult<Consumable>> ConsumablesDataProvider(GridDataProviderRequest<Consumable> request)
        {
            //TODO: might be able to move the get to here rather than param
            if (consumableListItems is null)
            {
                
                consumableListItems = await _loanManager.GetConsumablesForALoan(paramLoan.LoanId);
            }

            return await Task.FromResult(request.ApplyTo(consumableListItems));
        }


        private async Task OnSelectConsumableClick(Consumable? item)
        {
           
            await OnConsumableSelected.InvokeAsync(item);
        }

    }
}