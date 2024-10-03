
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

        public List<PatientListItem> GetPatientList()
        {
            var dto = _dynamicResponseRepository.GetPatientList();
            return GetPatientListItemsFromDto(dto);
        }

        private static List<PatientListItem> GetPatientListItemsFromDto(IEnumerable<PatientListItemCx> Dto)
        {
            if (Dto != null)
            {
                List<PatientListItem> PatientItems = new List<PatientListItem>();

                foreach (PatientListItemCx item in Dto)
                {
                    PatientListItem Loan = new PatientListItem();
                    PatientBase Patient= new PatientBase();
                    List<Loan> Loans = new List<Loan>();

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
                    Patient.DateofBirth = item.Patient.DateofBirth;
                    Patient.Telephone2 = item.Patient.Telephone2;
                    Patient.Telephone1 = item.Patient.Telephone1;


                    foreach (LoanCx stock in item.Loans)
                    {
                        Loan s = new Loan();
                        s.Id = stock.Id;
                        s.EquipmentId = stock.EquipmentId;
                        s.EquipmentName = stock.EquipmentName;
                        s.SerialNumber = stock.SerialNumber;
                        s.ClinicalReference = stock.ClinicalReference;   
                        s.LoanDate = stock.LoanDate;
                        Loans.Add(s);
                    }

                    Loan.Patient = Patient;
                    Loan.Loans = Loans;
                    PatientItems.Add(Loan);
                       
                }

                return PatientItems;
            }
            return null;
        }
    }
}
