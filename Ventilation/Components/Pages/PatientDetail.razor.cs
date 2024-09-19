using Microsoft.AspNetCore.Components;

namespace Ventilation.Components.Pages
{
    public partial class PatientDetail
    {
        [Parameter]
        public int? InternalPatientId { get; set; }

        [SupplyParameterFromForm]
        private Patient? Model { get; set; }

        //protected override void OnInitialized() => Model ??= new();

        protected override void OnInitialized()
        {
            Model = new Patient();
            Model.InternalPatientId = InternalPatientId;
            Model.HospitalNumber = "k65000";
            Model.NHSNumber = "555 555 5555";
            Model.Surname = "Smith";
            Model.Forename = "John";
            Model.Telephone1 = "07704 675888";
            Model.Telephone2 = "01782 563666";
            Model.Address1 = "First Address Line";
            Model.Address2 = "Second Address Line";
            Model.Address3 = "Third Address Line";
            Model.Address4 = "Fourth Address Line";
            Model.PostCode = "CQ3 9BT";
            Model.DoB = new DateTime(1972, 1, 12);



            //Additional outside MIDAS
            Model.PatientStatus = enumPatientStatus.OnMachine;
            Model.DischargeDate = new DateTime(2024, 11, 8);
            Model.DischargeStatus = enumDischargeStatus.NotDischarged;
            Model.DateInitiated = new DateTime(2023, 6, 14);
            Model.CCG = "15E";
            Model.Diagnosis = "Patient has MS";
            Model.Dependency = enumDependency.High;
            Model.Tracheostomy = false;
            Model.HomeService = true;
            Model.HomeVisit = true;
            Model.SmokingStatus = enumSmoker.Current;
            Model.PegDate = new DateTime(2024, 7, 11);
            Model.Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque arcu odio, sagittis sit amet lobortis sed, sodales at ex. Phasellus convallis convallis feugiat. Nunc mi justo, laoreet dictum ultricies pharetra, euismod ac purus. Praesent ut feugiat ante. Nunc consequat enim ut massa tempus accumsan. Maecenas et dapibus felis. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc tincidunt malesuada auctor. Sed vel venenatis metus. Nulla imperdiet, elit in finibus porttitor, ipsum nisl fermentum nisi, vitae dignissim nisi erat ut risus. Duis euismod lobortis lectus at dapibus. Nunc ex leo, cursus non neque in, egestas placerat libero. In massa arcu, suscipit ac placerat non, molestie ut diam.";
            
        }


        private void Submit()
        {
            Logger.LogInformation("InternalPatientId = {InternalPatientId}", Model?.Id);
        }

        //protected override void OnParametersSet()
        //{
        //    var test = InternalPatientId;
        //}


        public class Patient
        {
            //basic patient data
            public string? Id { get; set; }
            public int? InternalPatientId { get; set; }
            public string? HospitalNumber { get; set; }
            public string? NHSNumber { get; set; }
            public string? Surname { get; set; }
            public string? Forename { get; set; }
          
            public string? Address1 { get; set; }
            public string? Address2 { get; set; }
            public string? Address3 { get; set; }
            public string? Address4 { get; set; }
            public string? PostCode { get; set; }
            public string? Telephone1 { get; set; }
            public string? Telephone2 { get; set; }
            public DateTime? DoB { get; set; }

            //Additional
            public DateTime? DischargeDate { get; set; }
            public DateTime? DateInitiated { get; set; }
            public enumPatientStatus? PatientStatus { get; set; }
            public enumDischargeStatus? DischargeStatus { get; set; }
            public string? CCG { get; set; }
            public string? Diagnosis { get; set; }
            public enumDependency Dependency { get; set; }
            public bool Tracheostomy { get; set; }
            public bool HomeVisit { get; set; }
            public bool HomeService { get; set; }
            public enumSmoker SmokingStatus { get; set; }
            public DateTime? PegDate { get; set; }
            public string? Comments { get; set; }

        }




        //enum for drop downs
        public enum enumPatientStatus {None, OnMachine, NotonMachine }
        public enum enumDischargeStatus { NotDischarged, Discharged }
        public enum enumDependency { Low, Medium, High }
        public enum enumSmoker { Never, UsedTo, Current }

    }




}