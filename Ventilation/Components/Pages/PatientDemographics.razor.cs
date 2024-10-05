using BAL.Managers;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Models;
using System.Reflection;

namespace Ventilation.Components.Pages
{
    public partial class PatientDemographics
    {

        [Parameter]
        public int InternalPatientId { get; set; }

        [Parameter]
        public int? patientId { get; set; }

        [Inject]
        IPatientManager _patientManager { get; set; }

        Domain.Models.PatientBase patient = new();
        Domain.Models.PatientDetail patientDetail = new();
        bool IsVentilationPatient = false;
        List<ToastMessage> messages = new List<ToastMessage>();
        Tabs tabs = default!;

        protected override async Task OnInitializedAsync()
        {
            patientId = null;
            // do we want to get the patient and pass it to the banner, or pass the internalPatientId to the banner, and then let the banner get the data???
            
            patient = await _patientManager.GetPatient(InternalPatientId);

            patientDetail = await  _patientManager.GetPatientDetail(InternalPatientId);
            
            //if the patient has a Ventilation id then allow the loans and activity tabs
            if(patientDetail.Id != null) {
                patientId = patientDetail.Id;
                IsVentilationPatient = true;
                StateHasChanged();
            }
            else
            {
                patientId = null;
            }


        }

        //Event callback from child component after saving additional information
        protected async Task PatientIdChange(int? Id)
        {
            await Task.Delay(100);
            if (Id != null)
            {

                patientId = Id;


                IsVentilationPatient = true;
                StateHasChanged();
              
                ShowMessage(ToastType.Success);
                await tabs.ShowTabByNameAsync("Loans");
            }

        }



        private void ShowMessage(ToastType toastType) => messages.Add(CreateSaveMessage(toastType));

        private ToastMessage CreateSaveMessage(ToastType toastType)
    => new ToastMessage
    {
        Type = toastType,
        Message = $"Patient Saved!",
    };
    }
}