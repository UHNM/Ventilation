using DAL.Repositories;
using Domain.Entities.Complex;
using Domain.Models;

namespace BAL.Managers.DefaultImplementations
{
    public class PatientManager : IPatientManager
    {
        private readonly IPatientRepository _dynamicResponseRepository;

        public PatientManager(IPatientRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }

        public async Task<PatientBase> GetPatient(int internalPatientId)
        {
            var dto = await _dynamicResponseRepository.GetPatient(internalPatientId);


            return await Task.FromResult(GetPatientFromDto(dto));
        }

        public async Task<PatientDetail> GetPatientDetail(int internalPatientId)
        {
            var dto = await _dynamicResponseRepository.GetPatientDetail(internalPatientId);
            return await Task.FromResult(GetPatientDetailFromDto(dto));
        }


        public PatientBase FindPatient(string hospitalNumber)
        {
            var dto = _dynamicResponseRepository.FindPatient(hospitalNumber);
            return GetPatientFromDto(dto);
        }


        public async Task<int> SavePatient(PatientDetail patient)
        {
            var dto = await _dynamicResponseRepository.SavePatient(patient);
            return await Task.FromResult(dto);
        }


        public async Task<int> SavePatientLoan(Loan loan)
        {
            var dto = await _dynamicResponseRepository.SavePatientLoan(loan);
            return await Task.FromResult(dto);
        }


        private static PatientBase GetPatientFromDto(PatientBaseCx Dto)
        {
            if (Dto != null)
            {
                PatientBase Patient = new PatientBase();

                Patient.InternalPatientId = Dto.InternalPatientId;
                Patient.Id = Dto.Id;
                Patient.HospitalNumber = Dto.HospitalNumber;
                Patient.NHSNumber = Dto.NHSNumber;
                Patient.Forename = Dto.Forename;
                Patient.Surname = Dto.Surname;
                Patient.Address1 = Dto.Address1;
                Patient.Address2 = Dto.Address2;
                Patient.Address3 = Dto.Address3;
                Patient.Address4 = Dto.Address4;
                Patient.PostCode = Dto.PostCode;
                Patient.DateofBirth = Dto.DateofBirth;
                Patient.Telephone2 = Dto.Telephone2;
                Patient.Telephone1 = Dto.Telephone1;
                Patient.CCG = Dto.CCG;

                return Patient;
            }
            return null;
        }

        private static PatientDetail GetPatientDetailFromDto(PatientDetailCx Dto)
        {
            if (Dto != null)
            {
                PatientDetail Patient = new PatientDetail();

                Patient.InternalPatientId = Dto.InternalPatientId;
                Patient.Id = Dto.Id;

                Patient.PatientStatus = Dto.PatientStatus;
                Patient.DischargeStatus = Dto.DischargeStatus;
                Patient.DischargeDate = Dto.DischargeDate;
                Patient.DateInitiated = Dto.DateInitiated;

                Patient.DiagnosisCategory = Dto.DiagnosisCategory;
                Patient.DiagnosisSubCategory = Dto.DiagnosisSubCategory;
                Patient.DiagnosisOther = Dto.DiagnosisOther;
                Patient.Dependency = Dto.Dependency;
                Patient.Tracheostomy = Dto.Tracheostomy;
                Patient.HomeService = Dto.HomeService;
                Patient.HomeVisit = Dto.HomeVisit;
                Patient.SmokingStatus = Dto.SmokingStatus;
                Patient.PegDate = Dto.PegDate;
                Patient.Comments = Dto.Comments;
                Patient.FundingStartDate = Dto.FundingStartDate;
                Patient.LoneWorker = Dto.LoneWorker;

                return Patient;
            }
            return null;
        }

        public async Task<List<Loan>> GetPatientLoans(int? PatientId)
        {
            var dto = await _dynamicResponseRepository.GetPatientLoans(PatientId);
            return await Task.FromResult(GetPatientLoansFromDto(dto));
        }

        private static List<Loan> GetPatientLoansFromDto(IEnumerable<LoanCx> Dto)
        {
            if (Dto != null)
            {
                List<Loan> Loans = new List<Loan>();

              
                    foreach (LoanCx loan in Dto)
                    {
                        Loan s = new Loan();
                        s.LoanId = loan.LoanId;
                        s.PatientId = loan.PatientId;
                        s.LoanDate = loan.LoanDate;
                        s.StockId = loan.StockId;
                        s.EquipmentId = loan.EquipmentId;
                        s.EquipmentName = loan.EquipmentName;
                        s.SerialNumber = loan.SerialNumber;
                        s.ClinicalReference = loan.ClinicalReference;
                        s.ServiceDate = loan.ServiceDate;
                        s.LoanDate = loan.LoanDate;
                        s.EquipmentType = loan.EquipmentType;
                        s.EquipmentTypeId = loan.EquipmentTypeId;
                        s.SupplierName = loan.SupplierName;
                        Loans.Add(s);
                    }

                return Loans;
            }
            return null;
        }


    }
}
