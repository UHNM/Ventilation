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
       
        IQueryable<PatientListItem>? patientlist;
        
        
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