using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection;

namespace Ventilation.Components.Shared
{
    public partial class PatientLoanItem
    {
        [Parameter]
        public Loan? loan { get; set; }
        Tabs tabs = default!;
        private Modal modal = default!;


        protected override void OnInitialized()
        {
           


        }

        private async Task OnEditLoanClick()
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("PatientId", loan.PatientId);
            
            await modal.ShowAsync<Ventilation.Components.Shared.LoanComponents.LoanWrapper>(title: "Edit Loan for Patient: " + loan.PatientId, parameters: parameters);
        }

        private async Task OnHideModalClick()
        {
            await modal.HideAsync();
        }

    }
}