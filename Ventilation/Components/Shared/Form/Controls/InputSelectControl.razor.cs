using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Shared.Form.Controls
{
    public partial class InputSelectControl
    {
        [Parameter]
        public PrescriptionQuestion? viewModelProperty { get; set; }

        public string? controlType { get; set; }
        public string? controlLabel { get; set; }
        public List<PropertyOption>? controlOptions { get; set; }

        protected override void OnInitialized()
        {
            controlType = viewModelProperty.uiControlType;
            controlLabel = viewModelProperty.DisplayName;

            controlOptions = new List<PropertyOption>();
            if(viewModelProperty.Options != null)
            {
                controlOptions.AddRange(viewModelProperty.Options);

            }
        }

    }
}