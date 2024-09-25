
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


        public IEnumerable<PatientLoanCx> GetPatientList()
        {
            IEnumerable<PatientLoanCx> loans = new List<PatientLoanCx>();
         
            PatientBaseCx p = new PatientBaseCx();
            p.Id = 11111;
            p.InternalPatientId = 13131;
            p.HospitalNumber = "K65000";
            p.NHSNumber = "666 6666 666";
            p.Surname = "Smith";
            p.Forename = "John";

            StockItemCx s = new StockItemCx();
            s.SerialNumber = "Serial 1";
            s.EquipmentName = "Nippy 1000";
            s.Id = 1;
            s.EquipmentId = 2;
            s.ClinicalReference = "Clin Ref 1";
            s.LoanDate = new DateTime(2024, 3, 16);

            StockItemCx s1 = new StockItemCx();
            s1.SerialNumber = "Serial 2";
            s1.EquipmentName = "Another Vent";
            s1.Id = 1;
            s1.EquipmentId = 2;
            s1.ClinicalReference = "Clin Ref 2";
            s1.LoanDate = new DateTime(2024, 10, 30);

            PatientLoanCx l1 = new PatientLoanCx();

            l1.Patient = p;

            List<StockItemCx>? items1 = new List<StockItemCx>();
            items1.Add(s);
            items1.Add(s1);
            l1.Loans = items1;


            loans = loans.Append(l1);


            PatientBaseCx p1 = new PatientBaseCx();
            p1.Id = 11111;
            p1.InternalPatientId = 13131;
            p1.HospitalNumber = "J13452";
            p1.NHSNumber = "444 4444 555";
            p1.Surname = "Jones";
            p1.Forename = "Duncan";

            StockItemCx s2 = new StockItemCx();
            s2.SerialNumber = "Serial 3";
            s2.EquipmentName = "CPAP Mask";
            s2.Id = 1;
            s2.EquipmentId = 2;
            s2.ClinicalReference = "Clin Ref 33232";
            s2.LoanDate = new DateTime(2023, 7, 21);

            StockItemCx s3 = new StockItemCx();
            s3.SerialNumber = "Serial 4";
            s3.EquipmentName = "A different Vent";
            s3.Id = 1;
            s3.EquipmentId = 2;
            s3.ClinicalReference = "Clin Ref 5345345";
            s3.LoanDate = new DateTime(2024, 01, 19);

            StockItemCx s4 = new StockItemCx();
            s3.SerialNumber = "Serial 5";
            s3.EquipmentName = "Nippy 1000";
            s3.Id = 1;
            s3.EquipmentId = 2;
            s3.ClinicalReference = "Clin Ref 99999";
            s3.LoanDate = new DateTime(2024, 01, 07);
            PatientLoanCx l2 = new PatientLoanCx();
            l2.Patient = p1;

            List<StockItemCx>? items2 = new List<StockItemCx>();
            items2.Add(s2);
            items2.Add(s3);
            items2.Add(s4);
            l2.Loans = items2;

            loans = loans.Append(l2);

            return loans;
        }

    }
}
