using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.Form.Controls
{
    public partial class InputCheckBoxControl
    {
        [Parameter]
        public PrescriptionQuestion? viewModelProperty { get; set; }

        public string? controlType { get; set; }
        public string? controlLabel { get; set; }

        protected override void OnInitialized()
        {
            controlType = viewModelProperty.uiControlType;
            controlLabel = viewModelProperty.DisplayName;

        }

    }
}