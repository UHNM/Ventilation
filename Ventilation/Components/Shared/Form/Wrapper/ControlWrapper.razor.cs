using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.Form.Wrapper
{
    public partial class ControlWrapper
    {
        //TODO: need to add InputDateTime Control
        //TODO: need to handle validators & required etc for all controls
        [Parameter]
        public PrescriptionQuestion? viewModelProperty { get; set; }
    }
}