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

namespace Ventilation.Components.Shared.PatientComponents
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




        //TODO: where are the lookup values for patient details going to be stored?
        //Patient Status
        private IEnumerable<Lookup> statuses = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedStatuses =>
        statuses.Where(s => s.Key != PatientDetail.PatientStatus);

        Lookup? selectedStatus => PatientDetail.PatientStatus.HasValue ?
                            statuses.First(d => d.Key == PatientDetail.PatientStatus) :
                            default;

        //Dependency
        private IEnumerable<Lookup> dependencies = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedDependencies =>
        dependencies.Where(s => s.Key != PatientDetail.Dependency);

        Lookup? selectedDependency => PatientDetail.Dependency.HasValue ?
                            dependencies.First(d => d.Key == PatientDetail.Dependency) :
                            default;

        //Diagnosis Category
        private IEnumerable<Lookup> diagnosisCategories = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedDiagnosisCategories =>
        diagnosisCategories.Where(s => s.Key != PatientDetail.DiagnosisCategory);

        Lookup? selectedDiagnosisCategory => PatientDetail.DiagnosisCategory.HasValue ?
                            diagnosisCategories.First(d => d.Key == PatientDetail.DiagnosisCategory) :
                            default;

        //Diagnosis Sub Category
        private IEnumerable<Lookup> diagnosisSubCategories = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedDiagnosisSubCategories =>
        diagnosisSubCategories.Where(s => s.Key != PatientDetail.DiagnosisSubCategory);

        Lookup? selectedDiagnosisSubCategory => PatientDetail.DiagnosisSubCategory.HasValue ?
                            diagnosisSubCategories.First(d => d.Key == PatientDetail.DiagnosisSubCategory) :
                            default;

        //Diagnosis Discharged Status
        private IEnumerable<Lookup> dischargedStatuses = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedDischargeStatuses =>
        dischargedStatuses.Where(s => s.Key != PatientDetail.DischargeStatus);

        Lookup? selectedDischargeStatus => PatientDetail.DischargeStatus.HasValue ?
                            dischargedStatuses.First(d => d.Key == PatientDetail.DischargeStatus) :
                            default;


        //Smoking Status
        private IEnumerable<Lookup> smokingStatuses = Enumerable.Empty<Lookup>();

        private IEnumerable<Lookup> unSelectedSmokingStatuses =>
        smokingStatuses.Where(s => s.Key != PatientDetail.SmokingStatus);

        Lookup? selectedSmokingStatus => PatientDetail.DischargeStatus.HasValue ?
                            smokingStatuses.First(d => d.Key == PatientDetail.SmokingStatus) :
                            default;



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
            d2.Value = "2";

            dependencies = dependencies.Append(d1);
            dependencies = dependencies.Append(d2);


            Lookup c1 = new Lookup();
            c1.Key = 1;
            c1.Value = "Neuromuscular disease";

            Lookup c2 = new Lookup();
            c2.Key = 2;
            c2.Value = "Motor Neurone Disease";

            Lookup c3 = new Lookup();
            c3.Key = 3;
            c3.Value = "Chronic airways Disease";

            Lookup c4 = new Lookup();
            c4.Key = 4;
            c4.Value = "Musculoskeletal";


            Lookup c5 = new Lookup();
            c5.Key = 5;
            c5.Value = "Obesity and Obesity related disease";

            diagnosisCategories = diagnosisCategories.Append(c1);
            diagnosisCategories = diagnosisCategories.Append(c2);
            diagnosisCategories = diagnosisCategories.Append(c3);
            diagnosisCategories = diagnosisCategories.Append(c4);
            diagnosisCategories = diagnosisCategories.Append(c5);

            Lookup c6 = new Lookup();
            c6.Key = 1;
            c6.Value = "Sub Category 1";

            Lookup c7 = new Lookup();
            c7.Key = 2;
            c7.Value = "Sub Category 2";

            Lookup c8 = new Lookup();
            c8.Key = 3;
            c8.Value = "Sub Category 3";

            diagnosisSubCategories = diagnosisSubCategories.Append(c6);
            diagnosisSubCategories = diagnosisSubCategories.Append(c7);
            diagnosisSubCategories = diagnosisSubCategories.Append(c8);


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

            if (PatientDetail.Id != null)
            {
                message = "Patient Updated!";
            }

            int? Id = await _patientManager.SavePatient((PatientDetail)context.Model);

            ////TODO: need to pass the newly created PatientDetail object back to the parent
            ////Options, 1. Just creat a new PatientDetail object here from the Model and add the Id, 2. return the PatientDetail object from the save 3. Do a get PatientDetail method after the save once we have the Id

            //PatientBase p = new PatientBase();
            //p.Id = Id;
            //p.InternalPatientId = PatientDetail.InternalPatientId;


            await OnPatientSaved.InvokeAsync(Id);

        }


    }

    public class Lookup
    {
        public int? Key { get; set; }
        public string? Value { get; set; }
    }


}