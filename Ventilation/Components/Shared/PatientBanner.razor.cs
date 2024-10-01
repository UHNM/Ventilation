using BAL.Managers;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared
{
    public partial class PatientBanner
    {
        [Parameter]
        public Domain.Models.PatientBase Patient { get; set; }



    }
}