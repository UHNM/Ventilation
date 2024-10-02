using BAL.Managers;
using BlazorBootstrap;
using Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http.Json;

using static System.Net.WebRequestMethods;

namespace Ventilation.Components.Shared
{
    public partial class PatientAdditional
    {
        [Parameter]
        public PatientDetail? PatientDetail { get; set; }

        Dictionary<string, object> inputTextAreaAttributesComments = new Dictionary<string, object>();

        [Inject]
        IPatientManager _patientManager { get; set; }

      
        [Parameter]
        public EventCallback<int?> OnPatientSaved { get; set; }


        private string saveButtonText = "Save";





        //Patient Status
        private IEnumerable<Lookup> statuses = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedStatuses =>
        statuses.Where(s => s.Key != PatientDetail.PatientStatus);

        Lookup? selectedStatus => PatientDetail.PatientStatus.HasValue ?
                            statuses.First(d => d.Key == this.PatientDetail.PatientStatus) :
                            default(Lookup);

        //Dependency
        private IEnumerable<Lookup> dependencies = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedDependencies =>
        dependencies.Where(s => s.Key != PatientDetail.Dependency);

        Lookup? selectedDependency => PatientDetail.Dependency.HasValue ?
                            dependencies.First(d => d.Key == this.PatientDetail.Dependency) :
                            default(Lookup);

        //Diagnosis Category
        private IEnumerable<Lookup> diagnosisCategories = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedDiagnosisCategories =>
        diagnosisCategories.Where(s => s.Key != PatientDetail.DiagnosisCategory);

        Lookup? selectedDiagnosisCategory => PatientDetail.DiagnosisCategory.HasValue ?
                            diagnosisCategories.First(d => d.Key == this.PatientDetail.DiagnosisCategory) :
                            default(Lookup);

        //Diagnosis Sub Category
        private IEnumerable<Lookup> diagnosisSubCategories = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedDiagnosisSubCategories =>
        diagnosisSubCategories.Where(s => s.Key != PatientDetail.DiagnosisSubCategory);

        Lookup? selectedDiagnosisSubCategory => PatientDetail.DiagnosisSubCategory.HasValue ?
                            diagnosisSubCategories.First(d => d.Key == this.PatientDetail.DiagnosisSubCategory) :
                            default(Lookup);

        //Diagnosis Discharged Status
        private IEnumerable<Lookup> dischargedStatuses = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedDischargeStatuses =>
        dischargedStatuses.Where(s => s.Key != PatientDetail.DischargeStatus);

        Lookup? selectedDischargeStatus => PatientDetail.DischargeStatus.HasValue ?
                            dischargedStatuses.First(d => d.Key == this.PatientDetail.DischargeStatus) :
                            default(Lookup);


        //Smoking Status
        private IEnumerable<Lookup> smokingStatuses = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedSmokingStatuses =>
        smokingStatuses.Where(s => s.Key != PatientDetail.SmokingStatus);

        Lookup? selectedSmokingStatus => PatientDetail.DischargeStatus.HasValue ?
                            smokingStatuses.First(d => d.Key == this.PatientDetail.SmokingStatus) :
                            default(Lookup);



        protected override async Task OnInitializedAsync()
        {
            //TODO: needs to be async due to component base, require further investigation
            await Task.Delay(10);

            inputTextAreaAttributesComments.Add("rows", "4");
            inputTextAreaAttributesComments.Add("cols", "120");

          

            // HttpClient client = new HttpClient();
            //var statuses = await client.GetFromJsonAsync<Lookup[]>("status.json");


            // no idea where the enums / lookups will come from yet
            Lookup s2 = new Lookup();
            s2.Key = 1;
            s2.Value = "Under Monitoring";

            Lookup s3 = new Lookup();
            s3.Key = 2;
            s3.Value = "On Machine";
           
            statuses = statuses.Append(s2);
            statuses = statuses.Append(s3);

            Lookup d1 = new Lookup();
            d1.Key = 1;
            d1.Value = "1";

            Lookup d2 = new Lookup();
            d2.Key = 2;
            d2.Value ="2";

            dependencies = dependencies.Append(d1);
            dependencies = dependencies.Append(d2);


            Lookup c1 = new Lookup();
            c1.Key = 1;
            c1.Value = "MND";

            Lookup c2 = new Lookup();
            c2.Key = 2;
            c2.Value = "COPD";

            diagnosisCategories = diagnosisCategories.Append(c1);
            diagnosisCategories = diagnosisCategories.Append(c2);

            Lookup c3 = new Lookup();
            c3.Key = 1;
            c3.Value = "Sub Category 1";

            Lookup c4 = new Lookup();
            c4.Key = 2;
            c4.Value = "Sub Category 2";

            Lookup c5 = new Lookup();
            c5.Key = 3;
            c5.Value = "Sub Category 3";

            diagnosisSubCategories = diagnosisSubCategories.Append(c3);
            diagnosisSubCategories = diagnosisSubCategories.Append(c4);
            diagnosisSubCategories = diagnosisSubCategories.Append(c5);


            Lookup d5 = new Lookup();
            d5.Key = 1;
            d5.Value = "Discharged from Service";

            Lookup d6 = new Lookup();
            d6.Key = 2;
            d6.Value = "RIP";

            Lookup d7 = new Lookup();
            d7.Key = 3;
            d7.Value = "Transferred Sleep";

            Lookup d8 = new Lookup();
            d8.Key = 4;
            d8.Value = "Transferred Other";

            dischargedStatuses = dischargedStatuses.Append(d5);
            dischargedStatuses = dischargedStatuses.Append(d6);
            dischargedStatuses = dischargedStatuses.Append(d7);
            dischargedStatuses = dischargedStatuses.Append(d8);


            Lookup sm1 = new Lookup();
            sm1.Key = 1;
            sm1.Value = "Current Smoker";

            Lookup sm2 = new Lookup();
            sm2.Key = 2;
            sm2.Value = "Ex Smoker";

            Lookup sm3 = new Lookup();
            sm3.Key = 3;
            sm3.Value = "Non Smoker";

            smokingStatuses = smokingStatuses.Append(sm1);
            smokingStatuses = smokingStatuses.Append(sm2);
            smokingStatuses = smokingStatuses.Append(sm3);

        }


       

        protected override async Task OnParametersSetAsync()
        {
            //TODO: needs to be async due to component base, require further investigation
            await Task.Delay(10);

            if (PatientDetail.Id != null)
            {
                saveButtonText = "Update";
            }

        }

        private async Task OnSavePatient(EditContext context)
        {
            //The internalPatientId will always be populated, but if the id is null its an insert, otherwise an update
            string message = "New Patient Added!";
            
            if(PatientDetail.Id != null)
            {
                 message = "Patient Updated!";
            }
           
            
            int? patientId = await _patientManager.SavePatient((PatientDetail)context.Model);
          
            await OnPatientSaved.InvokeAsync(patientId);

        }

       
    }

    public class Lookup
    {
        public int? Key { get; set; }
        public string? Value { get; set; }
    }

   
}