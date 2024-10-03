
using DAL.Contexts;
using Domain.Entities.Complex;

namespace DAL.Repositories.DefaultImplementations
{
    public class PatientListRepository : Repository, IPatientListRepository
    {
        public PatientListRepository(IVentilationContext context)
           : base(context)
        {
        }


        public IEnumerable<PatientListItemCx> GetPatientList()
        {
            IEnumerable<PatientListItemCx> loans = new List<PatientListItemCx>();
         
            PatientBaseCx p = new PatientBaseCx();
            p.Id = 11111;
            p.InternalPatientId = 13131;
            p.HospitalNumber = "K65000";
            p.NHSNumber = "666 6666 666";
            p.Surname = "Smith";
            p.Forename = "John";
            p.Address1 = "1 Main Road";
            p.Address2 = "Lazy Town";
            p.Address3 = "";
            p.Address4 = "Staffs";
            p.PostCode = "ST5 4BB";
            p.DateofBirth = new DateOnly(1972, 9, 23);
            p.Telephone1 = "01782 444666";
            p.Telephone2 = "07704 789555";

            LoanCx s = new LoanCx();
            s.SerialNumber = "Serial 1";
            s.EquipmentName = "Nippy 1000";
            s.Id = 1;
            s.EquipmentId = 2;
            s.ClinicalReference = "Clin Ref 1";
            s.LoanDate = new DateTime(2024, 3, 16);
            s.PatientId = 111111;
            s.EquipmentType = "Ventilator";

            LoanCx s1 = new LoanCx();
            s1.SerialNumber = "Serial 2";
            s1.EquipmentName = "Stellar";
            s1.Id = 1;
            s1.EquipmentId = 2;
            s1.EquipmentType = "Ventilator";
            s1.ClinicalReference = "Clin Ref 2";
            s1.LoanDate = new DateTime(2024, 10, 30);
            s1.PatientId = 111111;

            PatientListItemCx l1 = new PatientListItemCx();

            l1.Patient = p;

            List<LoanCx>? items1 = new List<LoanCx>();
            items1.Add(s);
            items1.Add(s1);
            l1.Loans = items1;


            loans = loans.Append(l1);


            PatientBaseCx p1 = new PatientBaseCx();
            p1.Id = 222222;
            p1.InternalPatientId = 13131;
            p1.HospitalNumber = "J13452";
            p1.NHSNumber = "444 4444 555";
            p1.Surname = "Jones";
            p1.Forename = "Duncan";
            p1.Address1 = "24 Sesame St";
            p1.Address2 = "Some Town";
            p1.Address3 = "";
            p1.Address4 = "Staffs";
            p1.PostCode = "ST5 4YB";
            p.DateofBirth = new DateOnly(1972, 9, 23);
            p.Telephone1 = "01782 444666";
            p.Telephone2 = "07704 789555";

            LoanCx s2 = new LoanCx();
            s2.SerialNumber = "Serial 3";
            s2.EquipmentName = "Neb 1";
            s1.EquipmentType = "Ventilator";
            s2.Id = 1;
            s2.EquipmentId = 2;
            s2.ClinicalReference = "Clin Ref 33232";
            s2.LoanDate = new DateTime(2023, 7, 21);
            s2.PatientId = 222222;

            LoanCx s3 = new LoanCx();
            s3.SerialNumber = "Serial 4";
            s3.EquipmentName = "A different Vent";
            s3.EquipmentType = "Ventilator";
            s3.Id = 1;
            s3.EquipmentId = 2;
            s3.ClinicalReference = "Clin Ref 5345345";
            s3.LoanDate = new DateTime(2024, 01, 19);
            s3.PatientId = 333333;

            LoanCx s4 = new LoanCx();
            s4.SerialNumber = "Serial 5";
            s4.EquipmentName = "Nippy 1000";
            s4.EquipmentType = "Ventilator";
            s4.Id = 1;
            s4.EquipmentId = 2;
            s4.ClinicalReference = "Clin Ref 99999";
            s4.LoanDate = new DateTime(2024, 01, 07);
            s4.PatientId = 222222;

            PatientListItemCx l2 = new PatientListItemCx();
            l2.Patient = p1;

            List<LoanCx>? items2 = new List<LoanCx>();
            items2.Add(s2);
            items2.Add(s3);
            items2.Add(s4);
            l2.Loans = items2;

            loans = loans.Append(l2);

            return loans;
        }

    }
}
