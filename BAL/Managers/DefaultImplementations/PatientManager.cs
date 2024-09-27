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

        public PatientDetail GetPatient(int internalPatientId)
        {
            var dto = _dynamicResponseRepository.GetPatient(internalPatientId);
            return GetPatientFromDto(dto);
        }


        public PatientDetail FindPatient(string hospitalNumber)
        {
            var dto = _dynamicResponseRepository.FindPatient(hospitalNumber);
            return GetPatientFromDto(dto);
        }


        private static PatientDetail GetPatientFromDto(PatientDetailCx Dto)
        {
            if (Dto != null)
            {
                PatientDetail Patient = new PatientDetail();

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

                Patient.PatientStatus = Dto.PatientStatus;
                Patient.DischargeStatus = Dto.DischargeStatus;
                Patient.DischargeDate = Dto.DischargeDate;  
                Patient.DateInitiated = Dto.DateInitiated;  
                Patient.CCG = Dto.CCG; 
                Patient.Diagnosis = Dto.Diagnosis;  
                Patient.Dependency = Dto.Dependency;
                Patient.Tracheostomy = Dto.Tracheostomy;
                Patient.HomeService = Dto.HomeService;
                Patient.HomeVisit = Dto.HomeVisit;
                Patient.SmokingStatus = Dto.SmokingStatus;
                Patient.PegDate = Dto.PegDate;
                Patient.Comments = Dto.Comments;

                return Patient;
            }
            return null;
        }




    }
}
