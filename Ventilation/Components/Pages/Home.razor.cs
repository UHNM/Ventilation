using BAL.Managers;
using Microsoft.AspNetCore.Components;
using static Ventilation.Components.Pages.PatientDetail;

namespace Ventilation.Components.Pages
{
    public partial class Home
    {
        [Inject]
        IPatientListManager _patientListManager { get; set; }

        IQueryable<Domain.Models.PatientLoan>? patientlist;

        protected override void OnInitialized()
        {
            var items = _patientListManager.GetPatientList(); ;
            patientlist = (items).AsQueryable();

        }

        



    }




}