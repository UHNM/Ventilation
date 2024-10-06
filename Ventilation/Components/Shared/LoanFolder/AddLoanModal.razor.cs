using BlazorBootstrap;
using Microsoft.AspNetCore.Components;


namespace Ventilation.Components.Shared.LoanFolder
{
    public partial class AddLoanModal
    {
        private Modal modal = default!;

        [Parameter]
        public int? PatientId { get; set; }

        public async Task OnAddLoanClick()
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("PatientId", PatientId);

            await modal.ShowAsync<AddLoan>(title: "Loan", parameters: parameters);
        }


        private async Task OnHideModalClick()
        {
            await modal.HideAsync();
        }


       
    }
}