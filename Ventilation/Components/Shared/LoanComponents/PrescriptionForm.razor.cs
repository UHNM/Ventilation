using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Models;

namespace Ventilation.Components.Shared.LoanComponents
{
    public partial class PrescriptionForm
    {
        [CascadingParameter]
        public Loan? paramLoan { get; set; }

        [Parameter]
        public Prescription? paramPrescription { get; set; }

        [Inject]
        IPrescriptionManager _prescriptionManager { get; set; }

        List<PrescriptionQuestion> prescriptionQuestions = new();

        //to delete
        public Loan? loanDetail = new();

        protected override async Task OnInitializedAsync()
        {

            if (paramPrescription != null)
            {
                //if an edit, pass in the prescription id
                prescriptionQuestions = await _prescriptionManager.GetPrescriptionQuestions(paramPrescription.EquipmentId, paramPrescription.Id);
                var xx = "";
            }
            else
            {
                //if new then won't have a prescription so pass the equipment id from the loan and leave the prescription Id as null
                prescriptionQuestions = await _prescriptionManager.GetPrescriptionQuestions(paramLoan.EquipmentId, null);
                var yy = "";
            }
        }

        private async Task OnSavePrescription(EditContext context)
        {
           //save the prescription

        }
    }
}