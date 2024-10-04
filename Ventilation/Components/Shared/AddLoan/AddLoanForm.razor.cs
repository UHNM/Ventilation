using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Ventilation.Components.Shared.AddLoan
{
    public partial class AddLoanForm
    {
        [Parameter]
        public StockItem? stockItem { get; set; }

        [Parameter]
        public int? patientId { get; set; }

        public Loan? loanDetail = new();

        protected override void OnInitialized()
        {
            if(loanDetail != null)
            {
                loanDetail.PatientId = patientId;
                loanDetail.StockId = stockItem.StockId;
                loanDetail.ClinicalReference = stockItem.ClinicalReference;
                loanDetail.ServiceDate = stockItem.ServiceDate;
                loanDetail.EquipmentName = stockItem.EquipmentName;
                loanDetail.SerialNumber = stockItem.SerialNumber;
                loanDetail.LoanDate = loanDetail.LoanDate;


                loanDetail.LoanDate = null; ; //new DateTime(2023, 10, 4);
              

            }
          
        }

        private async Task OnSaveLoan(EditContext context)
        {
            await Task.Delay(100);


        }

    }
}