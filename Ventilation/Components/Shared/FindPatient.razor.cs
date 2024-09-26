using BAL.Managers;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Ventilation.Components.Shared
{
    public partial class FindPatient
    {
        [Inject]
        IPatientManager _patientManager { get; set; }
        public PatientToFind? patientToFind = new();


        private void OnFindClick(EditContext context)
        {
             
          var patient = _patientManager.FindPatient(((PatientToFind)context.Model).HospitalNumber);
            
        }


        public class PatientToFind
        {
            public string? HospitalNumber { get; set; } = string.Empty;
        }
    }
}