using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.Form.Wrapper
{
    public partial class ControlWrapper
    {
        [Parameter]
        public PrescriptionQuestion? viewModelProperty { get; set; }
    }
}