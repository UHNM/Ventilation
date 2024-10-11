using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.ConsumableComponents
{
    public partial class ConsumableList
    {
        [Parameter]
        public List<Consumable>? paramConsumables { get; set; }

        [Parameter]
        public bool? paramIsEdit { get; set; }
    }
}