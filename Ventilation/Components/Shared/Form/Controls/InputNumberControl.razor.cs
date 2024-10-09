using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.Form.Controls
{
    public partial class InputNumberControl
    {
        [Parameter]
        public PrescriptionQuestion? viewModelProperty { get; set; }

        public string? controlType { get; set; }
        public string? controlLabel { get; set; }
        public int? controlValue { get; set; }

        protected override void OnInitialized()
        {
            controlType = viewModelProperty.uiControlType;
            controlLabel = viewModelProperty.DisplayName;
            controlValue = viewModelProperty.ResponseInteger;
        }
    }
}