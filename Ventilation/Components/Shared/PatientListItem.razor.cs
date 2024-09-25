using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared
{
    public partial class PatientListItem
    {
        [Parameter]
        public PatientLoan paramPatientLoan { get; set; }

        private PatientLoan? Model { get; set; }

        [Parameter]
        public  string paramLoan { get; set; }

        protected override void OnInitialized()
        {
            Model = new PatientLoan();
            Model = paramPatientLoan;

          //  var t = paramPatientLoan;
           
        }




    }
}