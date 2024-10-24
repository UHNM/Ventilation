using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.PrescriptionComponents
{
    public partial class PrescriptionWrapper
    {
        [Parameter]
        public Loan? paramLoan { get; set; }
       
        public bool? AddPrescription { get; set; }
        public bool? UserClickedAdd { get; set; }
        Prescription? prescriptionSelected = new();

        protected override async Task OnInitializedAsync()
        {
            UserClickedAdd = false;
        }

        private async Task OnAddPrescriptionClick()
        {
            await Task.Delay(100);
            UserClickedAdd = true;
        }

        protected async Task PrescriptionSelected(Prescription? p)
        {
            prescriptionSelected = p;
            await Task.Delay(100);
            StateHasChanged();
        }

        //Event callback from child component after saving the prescription form
        protected async Task OnPrescriptionChanged()
        {
            UserClickedAdd = false;
            prescriptionSelected = new(); 
            StateHasChanged();
              
                
        }


      
      


    }
}