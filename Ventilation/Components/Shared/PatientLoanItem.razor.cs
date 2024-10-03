using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared
{
    public partial class PatientLoanItem
    {
        [Parameter]
        public Loan? loan { get; set; }

        protected override void OnInitialized()
        {
           


        }
    }
}