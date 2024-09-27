using BAL.Managers;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection;

namespace Ventilation.Components.Pages
{
    public partial class PatientDemographics
    {

        [Parameter]
        public int InternalPatientId { get; set; }

        [Inject]
        IPatientManager _patientManager { get; set; }

      Domain.Models.PatientDetail patient = new();

        protected override void OnInitialized()
        {
              patient = _patientManager.GetPatient(InternalPatientId);

        }

        private void OnSavePatient(EditContext context)
        {


        }
    }
}