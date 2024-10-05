using BAL.Managers;
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

        [Inject]
        IPatientManager _patientManager { get; set; }

        [Parameter]
        public EventCallback<Loan?> OnLoanSaved { get; set; }


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
            int? Id = await _patientManager.SavePatientLoan((Loan)context.Model);

            //TODO: need to pass the newly created Loan object back to the parent
            //Options, 1. Just creat a new loan object here from the Model and add the Id, 2. return the loan object from the save 3. Do a get loan method after the save once we have the Id
            Loan l = new Loan();
            l.LoanId = Id;
            l.LoanDate = loanDetail.LoanDate;
            l.PatientId = patientId;
            l.StockId = stockItem.StockId;
            l.ClinicalReference = stockItem.ClinicalReference;
            l.ServiceDate = stockItem.ServiceDate;
            l.EquipmentName = stockItem.EquipmentName;
            l.SerialNumber = stockItem.SerialNumber;
            l.LoanDate = loanDetail.LoanDate;

            await OnLoanSaved.InvokeAsync(l);

        }

    }
}