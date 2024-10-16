using DAL.Contexts;
using Domain.Entities.Complex;
using System.Data.SqlClient;
using System.Data;
using Domain.Models;

namespace DAL.Repositories.DefaultImplementations
{
    public class PatientRepository : Repository, IPatientRepository
    {
        public PatientRepository(IVentilationContext context)
           : base(context)
        {
        }


        public async Task<int> SavePatient(PatientDetail patient)
        {
           //if the patient already has an Id , then update, otherwise insert
           //return the new Id to the front end
            
            int Id = 1000;

            await Task.Delay(200);
            return Id;




        }

        public async Task<int> SavePatientLoan(Loan loan)
        {
           //if tyhe loan Id is null do an insert, if not do an update. return the Loan Id

            int Id = 123456;

            await Task.Delay(200);
            return Id;




        }



        public async Task<PatientBaseCx> GetPatient(int internalPatientId)
        {
           
            PatientBaseCx p = new PatientBaseCx();
            
            p.Id = 111111;
            p.InternalPatientId = 13131;
            p.HospitalNumber = "C111";
            p.NHSNumber = "999 8886 777";
            p.Surname = "Bruce";
            p.Forename = "Fiona";
            p.Address1 = "1 Hospital Road";
            p.Address2 = "Ponte preth";
            p.Address3 = "";
            p.Address4 = "Staffs";
            p.PostCode = "ST5 4BB";
            p.DateofBirth = new DateOnly(1972, 9, 23);
            p.Telephone1 = "01782 444666";
            p.Telephone2 = "07704 789555";
            p.CCG = "Hereford & Worcester";


            await Task.Delay(200);
            return p;


         

        }



        public async Task<PatientDetailCx> GetPatientDetail(int internalPatientId)
        {
        
            //if the patient is in the ventilation system, return all patient details
            //otherwise will just be Midas stuff
            PatientDetailCx p = new PatientDetailCx();
            p.Id = 111111;
            p.InternalPatientId = 13131;

            p.PatientStatus = 1;
            p.DischargeDate = new DateTime(2024, 11, 8);
            p.DischargeStatus = 2;
            p.DateInitiated = new DateTime(2023, 6, 14);
            p.DiagnosisCategory = 1;
            p.DiagnosisSubCategory = 2;           
            p.DiagnosisOther = "Diagnosis Other";
            p.Dependency = 2;
            p.Tracheostomy = false;
            p.HomeService = true;
            p.HomeVisit = true;
            p.SmokingStatus = 3;
            p.PegDate = new DateTime(2024, 7, 11);
            p.FundingStartDate = new DateTime(2024, 3, 21);
            p.Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque arcu odio, sagittis sit amet lobortis sed, sodales at ex. Phasellus convallis convallis feugiat. Nunc mi justo, laoreet dictum ultricies pharetra, euismod ac purus. Praesent ut feugiat ante. Nunc consequat enim ut massa tempus accumsan. Maecenas et dapibus felis. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc tincidunt malesuada auctor. Sed vel venenatis metus. Nulla imperdiet, elit in finibus porttitor, ipsum nisl fermentum nisi, vitae dignissim nisi erat ut risus. Duis euismod lobortis lectus at dapibus. Nunc ex leo, cursus non neque in, egestas placerat libero. In massa arcu, suscipit ac placerat non, molestie ut diam.";
            p.LoneWorker = true;

            await Task.Delay(200);
            return p;
        }

        public PatientBaseCx FindPatient(string hospitalNumber)
        {
         

            //if the patient is in the ventilation system, return all patient details
            //otherwise will just be Midas stuff
            PatientBaseCx p = new PatientBaseCx();
            p.Id = 11111;
            p.InternalPatientId = 13131;
            p.HospitalNumber = "C111";
            p.NHSNumber = "999 8886 777";
            p.Surname = "Bruce";
            p.Forename = "Fiona";
            p.Address1 = "1 Hospital Road";
            p.Address2 = "Ponte preth";
            p.Address3 = "";
            p.Address4 = "Staffs";
            p.PostCode = "ST5 4BB";
            p.DateofBirth = new DateOnly(1972, 9, 23);
            p.Telephone1 = "01782 444666";
            p.Telephone2 = "07704 789555";
            p.CCG = "Hereford & Worcester";



            return p;
        }



        //get all loans for a ventilation patient id
        public async Task<IEnumerable<LoanCx>> GetPatientLoans(int? PatientId)
        {
            IEnumerable<LoanCx> loans = new List<LoanCx>();

            LoanCx s = new LoanCx();
            s.LoanId = 1000;
            s.SerialNumber = "Serial";
            s.EquipmentName = "Stellar";
            s.StockId = 99;
            s.EquipmentId = 2;
            s.ClinicalReference = "Clin Ref";
            s.LoanDate = new DateTime(2024, 3, 16);
            s.PatientId = 111111;
            s.EquipmentType = "Ventilator";
            s.EquipmentTypeId = 50;
            s.ServiceDate = new DateTime(2026, 3, 25);

            LoanCx s1 = new LoanCx();
            s1.LoanId = 2;
            s1.SerialNumber = "Serial 2";
            s1.EquipmentName = "Stellar";
            s1.StockId = 2;
            s1.EquipmentId = 2;
            s1.EquipmentType = "Ventilator";
            s.EquipmentTypeId = 50;
            s1.ClinicalReference = "Clin Ref 2";
            s1.LoanDate = new DateTime(2024, 10, 30);
            s1.PatientId = 111111;
            s1.ServiceDate = null;

            LoanCx s4 = new LoanCx();
            s4.LoanId = 5;
            s4.SerialNumber = "Serial 5";
            s4.EquipmentName = "Some Nebulizer";
            s4.EquipmentType = "Nebulizer";
            s.EquipmentTypeId = 51;
            s4.StockId = 3;
            s4.EquipmentId = 2;
            s4.ClinicalReference = "Clin Ref 99999";
            s4.LoanDate = new DateTime(2024, 01, 07);
            s4.PatientId = 111111;
            s4.ServiceDate = null;

            loans = loans.Append(s);
            loans = loans.Append(s1);
            loans = loans.Append(s4);
           
            await Task.Delay(100);
            return loans;
        }

    }
}
