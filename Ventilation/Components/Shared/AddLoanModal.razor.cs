using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace Ventilation.Components.Shared
{
    public partial class AddLoanModal
    {
        private Modal modal = default!;


        public async Task OnShowModalClick()
        {
            await modal.ShowAsync<AddLoan>(title: "Add Loan");
        }


        private async Task OnHideModalClick()
        {
            await modal.HideAsync();
        }

       
        private void OnModalHiding()
        {
          
        }

        private void OnModalHidden()
        {
           
        }

        private void OnModalHidePrevented()
        {
            
        }
    }
}