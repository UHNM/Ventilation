using BAL.Managers;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.LoanComponents
{
    public partial class PrescriptionForm
    {
        [Parameter]
        public Prescription? paramPrescription { get; set; }

        [Inject]
        IEquipmentManager _equipmentManager { get; set; }

        List<EquipmentProperty> equipmentProperties = new();


        protected override async Task OnInitializedAsync()
        {

            if (paramPrescription != null)
            {
                //should we pass in the Prescription Id also
                equipmentProperties = await _equipmentManager.GetEquipmentProperties(paramPrescription.EquipmentId);
                var xx = "";
            }


        }
    }
}