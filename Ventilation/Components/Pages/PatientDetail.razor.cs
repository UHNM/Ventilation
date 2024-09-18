using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Pages
{
    public partial class PatientDetail
    {
        [Parameter]
        public int Id { get; set; }



        protected override void OnParametersSet()
        {
            var test = Id;
        }




    }
}