using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared
{
    public partial class PatientListDetail
    {
        [Parameter]
        public PatientListItem? paramPatientListItem { get; set; }

      //  private PatientListItem? Model { get; set; }

      //  [Parameter]
      //  public string paramLoan { get; set; }

        protected override void OnInitialized()
        {
          //  Model = new PatientListItem();
          //  Model = paramPatientListItem;


        }




    }
}