using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Ventilation.Components.Shared.LoanComponents
{
    public partial class LoanForm
    {
        [Parameter]
        public StockItem? stockItem { get; set; }

        [Parameter]
        public int? patientId { get; set; }

        //if an edit we will have a loan object passed in, if a new loan, the object will be null
        [Parameter] public Loan? paramLoan { get; set; }

        [Inject]
        IPatientManager _patientManager { get; set; }

        [Parameter]
        public EventCallback<Loan?> OnLoanSaved { get; set; }

        [Parameter]
        public EventCallback<EventArgs> OnCancelLoan { get; set; }

        public Loan? loanDetail = new();

        protected override void OnInitialized()
        {
         
           if(paramLoan != null)
            {
                loanDetail.PatientId = patientId;
                loanDetail.StockId = paramLoan.StockId;
                loanDetail.ClinicalReference = paramLoan.ClinicalReference;
                loanDetail.ServiceDate = paramLoan.ServiceDate;
                loanDetail.EquipmentName = paramLoan.EquipmentName;
                loanDetail.SerialNumber = paramLoan.SerialNumber;
                loanDetail.LoanDate = paramLoan.LoanDate;
            }
            else
            {
                loanDetail.PatientId = patientId;
                loanDetail.StockId = stockItem.StockId;
                loanDetail.ClinicalReference = stockItem.ClinicalReference;
                loanDetail.ServiceDate = stockItem.ServiceDate;
                loanDetail.EquipmentName = stockItem.EquipmentName;
                loanDetail.SerialNumber = stockItem.SerialNumber;
                loanDetail.LoanDate = null; 
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
            l.StockId = loanDetail.StockId;
            l.ClinicalReference = loanDetail.ClinicalReference;
            l.ServiceDate = loanDetail.ServiceDate;
            l.EquipmentName = loanDetail.EquipmentName;
            l.SerialNumber = loanDetail.SerialNumber;
            l.LoanDate = loanDetail.LoanDate;

            await OnLoanSaved.InvokeAsync(l);

        }

        private async Task OnCancelLoanClick()
        {
            //let the parent component know to close the Modal
            await OnCancelLoan.InvokeAsync();
        }

    }
}