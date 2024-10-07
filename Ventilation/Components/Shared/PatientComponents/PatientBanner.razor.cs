using BAL.Managers;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.PatientComponents
{
    public partial class PatientBanner
    {
        [Parameter]
        public Domain.Models.PatientBase Patient { get; set; }



    }
}