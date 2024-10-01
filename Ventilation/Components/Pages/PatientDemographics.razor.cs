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

        Domain.Models.PatientBase patient = new();
        Domain.Models.PatientDetail patientDetail = new();

        protected override async Task OnInitializedAsync()
        {
            // do we want to get the patient and pass it to the banner, or pass the internalPatientId to the banner, and then let the banner get the data???
            patient = await _patientManager.GetPatient(InternalPatientId);
            patientDetail = await  _patientManager.GetPatientDetail(InternalPatientId);


        }

       
    }
}