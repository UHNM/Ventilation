
using DAL.Repositories;
using Domain.Entities.Complex;
using Domain.Models;

namespace BAL.Managers.DefaultImplementations
{
    public class PatientListManager : IPatientListManager
    {

        private readonly IPatientListRepository _dynamicResponseRepository;


        public PatientListManager(IPatientListRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }

        public List<PatientLoan> GetPatientList()
        {
            var dto = _dynamicResponseRepository.GetPatientList();
            return GetPatientLoanFromDto(dto);
        }

        private static List<PatientLoan> GetPatientLoanFromDto(IEnumerable<PatientLoanCx> Dto)
        {
            if (Dto != null)
            {
                List<PatientLoan> PatientLoans = new List<PatientLoan>();

                foreach (PatientLoanCx item in Dto)
                {
                   PatientLoan Loan = new PatientLoan();
                    PatientBase Patient= new PatientBase();
                    List<StockItem> StockItems = new List<StockItem>();

                    Patient.InternalPatientId = item.Patient.InternalPatientId;
                    Patient.Id = item.Patient.Id;
                    Patient.HospitalNumber = item.Patient.HospitalNumber;
                    Patient.NHSNumber = item.Patient.NHSNumber;
                    Patient.Forename =item.Patient.Forename;
                    Patient.Surname = item.Patient.Surname;
                    Patient.Address1 = item.Patient.Address1;
                    Patient.Address2 = item.Patient.Address2;
                    Patient.Address3 = item.Patient.Address3;
                    Patient.Address4 = item.Patient.Address4;
                    Patient.PostCode = item.Patient.PostCode;


                    foreach (StockItemCx stock in item.Loans)
                    {
                        StockItem s = new StockItem();
                        s.Id = stock.Id;
                        s.EquipmentId = stock.EquipmentId;
                        s.EquipmentName = stock.EquipmentName;
                        s.SerialNumber = stock.SerialNumber;
                        s.ClinicalReference = stock.ClinicalReference;   
                        s.LoanDate = stock.LoanDate;
                        StockItems.Add(s);
                    }

                    Loan.Patient = Patient;
                    Loan.Loans = StockItems;
                    PatientLoans.Add(Loan);
                       
                }

                return PatientLoans;
            }
            return null;
        }
    }
}
