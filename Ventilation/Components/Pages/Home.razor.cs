using BAL.Managers;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using System.Reflection;
using Ventilation.Components.Shared;

namespace Ventilation.Components.Pages
{
    public partial class Home
    {
        [Inject]
        IPatientListManager _patientListManager { get; set; }
       
        IQueryable<Domain.Models.PatientLoan>? patientlist;
        VentilationModal ventilationModal => new VentilationModal();


        protected override void OnInitialized()
        {
            var items = _patientListManager.GetPatientList(); ;
            patientlist = (items).AsQueryable();

        }

        private async Task OnAddPatientClick()
        {
          
            ventilationModal.OnShowModalClick();
        }





    }




}