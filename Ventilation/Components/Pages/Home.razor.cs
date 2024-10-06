using BAL.Managers;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using System.Reflection;
using Ventilation.Components.Shared;

namespace Ventilation.Components.Pages
{
    public partial class Home
    {
        [Inject]
        IPatientListManager _patientListManager { get; set; }

        private Modal modal = default!;

        List<Domain.Models.PatientListItem> patientList = new();



        protected override async Task OnInitializedAsync()
        {
            patientList = await _patientListManager.GetPatientList(); ;
       
        }

        private async Task OnHideModalClick()
        {
            await modal.HideAsync();
        }


        public async Task OnAddPatientClick()
        {
            await modal.ShowAsync<AddPatient>(title: "Add Patient");
        }


    }




}