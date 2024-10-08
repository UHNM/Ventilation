using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.LoanComponents
{
    public partial class PrescriptionList
    {

        [Parameter]
        public List<Prescription>? paramPrescriptions { get; set; }

        [Parameter]
        public bool? paramIsEdit { get; set; }


        //Event callback from child component after saving additional information
        protected async Task PrescriptionSelected(Prescription? p)
        {
            await Task.Delay(100);
            //if (stock != null)
            //{
            //    stockItemSelected = stock;
            //    StateHasChanged();
            //}

        }

        //private async Task OnAddPrescriptionClick()
        //{
        //    await Task.Delay(100);
        //}

    }
}