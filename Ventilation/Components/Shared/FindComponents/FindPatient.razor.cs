
using BAL.Managers;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection;

namespace Ventilation.Components.Shared.FindComponents
{
    public partial class FindPatient
    {
        [Inject]
        IPatientManager _patientManager { get; set; }
        public PatientToFind? patientToFind = new();
        PatientBase patientFound = new();

        private bool showPatient = false;



        private void OnFindClick(EditContext context)
        {
            patientFound = _patientManager.FindPatient(((PatientToFind)context.Model).HospitalNumber);

            if (patientFound != null)
            {
                showPatient = true;
            }

        }


        private void OnSavePatient(EditContext context)
        {


        }



        public class PatientToFind
        {
            public string? HospitalNumber { get; set; } = string.Empty;
        }
    }
}