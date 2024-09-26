using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Ventilation.Components.Shared
{
    public partial class FindPatient
    {
       
        public PatientToFind? patientToFind = new();


        private void OnFindClick(EditContext context)
        {
             var t =  ((PatientToFind)context.Model).HospitalNumber;
            var xx = "";
          
        }


        public class PatientToFind
        {
            public string? HospitalNumber { get; set; } = string.Empty;
        }
    }
}