using BAL.Managers;
using BAL.Managers.DefaultImplementations;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.StockComponents
{
    public partial class EquipmentList
    {
        [Inject]
        IEquipmentManager _equipmentManager { get; set; }

        [Inject]
        NavigationManager _navigationManager { get; set; }

        private IEnumerable<EquipmentBase> equipmentListItems = default!;
        private HashSet<EquipmentBase> selectedEquipmentItem = new();

        [Parameter]
        public EventCallback<EquipmentBase?> OnEquipmentSelected { get; set; }

        private async Task<GridDataProviderResult<EquipmentBase>> EquipmentItemsDataProvider(GridDataProviderRequest<EquipmentBase> request)
        {
            if (equipmentListItems is null) // pull employees only one time for client-side filtering, sorting, and paging
                equipmentListItems = await _equipmentManager.GetEquipmentList();

            return await Task.FromResult(request.ApplyTo(equipmentListItems));
        }


        private Task OnSelectedItemsChanged(HashSet<EquipmentBase> equipmentItems)
        {
            selectedEquipmentItem = equipmentItems is not null && equipmentItems.Any() ? equipmentItems : new();
            return Task.CompletedTask;
        }

        private async Task OnRowClick(GridRowEventArgs<EquipmentBase> args)
        {
            await OnEquipmentSelected.InvokeAsync(args.Item);
           
        }

    }
}