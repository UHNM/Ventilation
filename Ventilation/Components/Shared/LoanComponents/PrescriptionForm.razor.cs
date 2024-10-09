using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;

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
    }
}