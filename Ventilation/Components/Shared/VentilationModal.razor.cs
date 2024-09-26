using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace Ventilation.Components.Shared
{
    public partial class VentilationModal
    {
        [Inject]
        ToastService ToastService { get; set; } = default!;
         private Modal modal = default!;
        // Modal modal => new Modal();


        public async Task OnShowModalClick()
        {
            //var parameters = new Dictionary<string, object>();
            //parameters.Add("InternalPatientId", 321);
            //await modal.ShowAsync<AddPatient>(title: "Add Patient", parameters: parameters);
           
            await modal.ShowAsync<AddPatient>(title: "Add Patient");
        }



        //public async Task OnShowModalClick()
        //{
        //    await modal.ShowAsync();
        //}

        private async Task OnHideModalClick()
        {
            await modal.HideAsync();
        }

        private void OnModalShowing()
        {
            ToastService.Notify(new(ToastType.Primary, $"Event: Showing called. DateTime: {DateTime.Now}"));
        }

        private void OnModalShown()
        {
            ToastService.Notify(new(ToastType.Success, $"Event: Show called. DateTime: {DateTime.Now}"));
        }

        private void OnModalHiding()
        {
            ToastService.Notify(new(ToastType.Danger, $"Event: Hiding called. DateTime: {DateTime.Now}"));
        }

        private void OnModalHidden()
        {
            ToastService.Notify(new(ToastType.Warning, $"Event: Hide called. DateTime: {DateTime.Now}"));
        }

        private void OnModalHidePrevented()
        {
            ToastService.Notify(new(ToastType.Info, $"Event: Hide Prevented called. DateTime: {DateTime.Now}"));
        }
    }
}