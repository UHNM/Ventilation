using Domain.Models;
using Microsoft.AspNetCore.Components;
using Models;
using System.Xml.Serialization;
using Ventilation.Components.Shared.PatientComponents;

namespace Ventilation.Components.Shared.Form.Controls
{
    public partial class InputTextControl
    {
        [Parameter]
        public PrescriptionQuestion? viewModelProperty { get; set; }

        public string? controlType { get; set; }
        public string? controlLabel { get; set; }
        

        protected override void  OnInitialized()
        {
            controlType = viewModelProperty.uiControlType;
            controlLabel = viewModelProperty.DisplayName;
           
        }
    }
}