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
        public Domain.Models.PatientDetail PatientDetail { get; set; }

        
        
        private IEnumerable<Status> statuses = Enumerable.Empty<Status>();

        private IEnumerable<Status> unSelectedStatuses =>
        statuses.Where(s => s.Id != PatientDetail.PatientStatus);

        Status? selectedStatus => PatientDetail.PatientStatus.HasValue ?
                            statuses.First(d => d.Id == this.PatientDetail.PatientStatus) :
                            default(Status);


        private IEnumerable<Dependency> dependencies = Enumerable.Empty<Dependency>();

        private IEnumerable<Dependency> unSelectedDependencies =>
        dependencies.Where(s => s.Id != PatientDetail.Dependency);

        Dependency? selectedDependency => PatientDetail.Dependency.HasValue ?
                            dependencies.First(d => d.Id == this.PatientDetail.Dependency) :
                            default(Dependency);







        protected override async Task OnInitializedAsync()
        {
            // HttpClient client = new HttpClient();
            //var employees = await client.GetFromJsonAsync<Employee[]>("status.json");

            //statuses = Enumerable.Range(0, 2)
            //    .Select(i => new Status { Id = i, Name = $"Name{i}" });



            // no idea where the enums / lookups will come from yet
           
            Status s2 = new Status();
            s2.Id = 1;
            s2.Name = "Under Monitoring";

            Status s3 = new Status();
            s3.Id = 2;
            s3.Name = "On Machine";
           
            statuses = statuses.Append(s2);
            statuses = statuses.Append(s3);

            Dependency d1 = new Dependency();
            d1.Id = 1;

            Dependency d2 = new Dependency();
            d2.Id = 2;

            dependencies = dependencies.Append(d1);
            dependencies = dependencies.Append(d2);


        }



        private void OnSavePatient(EditContext context)
        {


        }

    }

    public class Status
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }

    public class Dependency
    {
        public int? Id { get; set; }
        //public string? Name { get; set; }
    }

}