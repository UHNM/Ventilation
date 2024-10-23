using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.PatientComponents
{
    public partial class PatientList
    {
        [Inject]
        IPatientListManager _patientListManager { get; set; }

        [Inject]
        NavigationManager _navigationManager { get; set; }

        private IEnumerable<PatientBase> patients = default!;
        private IEnumerable<Loan> patientLoans = default!;
        private PatientListLoan pl = default!;

        private async Task<GridDataProviderResult<PatientBase>> PatientLoansDataProvider(GridDataProviderRequest<PatientBase> request)
        {

            if (pl is null)
            {
                pl = await _patientListManager.GetPatientList();
                patients = pl.Patients;
                patientLoans = pl.PatientLoans;
            }
           
            return await Task.FromResult(request.ApplyTo(patients));
        }


        private IEnumerable<Loan> GetPatientLoans(int? patientId) => patientLoans.Where(i => i.PatientId == patientId);



        //private Task OnSelectedItemsChanged(HashSet<PatientBase> patients)
        //{
        // //   selectedStockItem = stockItems is not null && stockItems.Any() ? stockItems : new();
        //    return Task.CompletedTask;
        //}

        //private async Task OnRowClick(GridRowEventArgs<PatientBase> args)
        //{
        //    await Task.Delay(10);
        //    _navigationManager.NavigateTo("/patient/detail/" + args.Item.Id);
        //}

    }
}