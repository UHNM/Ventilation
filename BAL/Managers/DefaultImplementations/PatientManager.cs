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

                Patient.Diagnosis = Dto.Diagnosis;
                Patient.Dependency = Dto.Dependency;
                Patient.Tracheostomy = Dto.Tracheostomy;
                Patient.HomeService = Dto.HomeService;
                Patient.HomeVisit = Dto.HomeVisit;
                Patient.SmokingStatus = Dto.SmokingStatus;
                Patient.PegDate = Dto.PegDate;
                Patient.Comments = Dto.Comments;
                Patient.FundingStartDate = Dto.FundingStartDate;

                return Patient;
            }
            return null;
        }




    }
}
