﻿using DAL.Contexts;
using Domain.Entities.Complex;

namespace DAL.Repositories.DefaultImplementations
{
    public class PatientRepository : Repository, IPatientRepository
    {
        public PatientRepository(IVentilationContext context)
           : base(context)
        {
        }



        public PatientDetailCx GetPatient(int internalPatientId)
        {
            IEnumerable<PatientLoanCx> loans = new List<PatientLoanCx>();

            //if the patient is in the ventilation system, return all patient details
            //otherwise will just be Midas stuff
            PatientDetailCx p = new PatientDetailCx();
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


            p.PatientStatus = 1;
            p.DischargeDate = new DateTime(2024, 11, 8);
            p.DischargeStatus = 2;
            p.DateInitiated = new DateTime(2023, 6, 14);
            p.CCG = "15E";
            p.Diagnosis = "Patient has MS";
            p.Dependency = 3;
            p.Tracheostomy = false;
            p.HomeService = true;
            p.HomeVisit = true;
            p.SmokingStatus = 4;
            p.PegDate = new DateTime(2024, 7, 11);
            p.Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque arcu odio, sagittis sit amet lobortis sed, sodales at ex. Phasellus convallis convallis feugiat. Nunc mi justo, laoreet dictum ultricies pharetra, euismod ac purus. Praesent ut feugiat ante. Nunc consequat enim ut massa tempus accumsan. Maecenas et dapibus felis. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc tincidunt malesuada auctor. Sed vel venenatis metus. Nulla imperdiet, elit in finibus porttitor, ipsum nisl fermentum nisi, vitae dignissim nisi erat ut risus. Duis euismod lobortis lectus at dapibus. Nunc ex leo, cursus non neque in, egestas placerat libero. In massa arcu, suscipit ac placerat non, molestie ut diam.";


            return p;
        }

        public PatientDetailCx FindPatient(string hospitalNumber)
        {
            IEnumerable<PatientLoanCx> loans = new List<PatientLoanCx>();

            //if the patient is in the ventilation system, return all patient details
            //otherwise will just be Midas stuff
            PatientDetailCx p = new PatientDetailCx();
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


            p.PatientStatus = 1;
            p.DischargeDate = new DateTime(2024, 11, 8);
            p.DischargeStatus = 2;
            p.DateInitiated = new DateTime(2023, 6, 14);
            p.CCG = "15E";
            p.Diagnosis = "Patient has MS";
            p.Dependency = 3;
            p.Tracheostomy = false;
            p.HomeService = true;
            p.HomeVisit = true;
            p.SmokingStatus = 4;
            p.PegDate = new DateTime(2024, 7, 11);
            p.Comments = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque arcu odio, sagittis sit amet lobortis sed, sodales at ex. Phasellus convallis convallis feugiat. Nunc mi justo, laoreet dictum ultricies pharetra, euismod ac purus. Praesent ut feugiat ante. Nunc consequat enim ut massa tempus accumsan. Maecenas et dapibus felis. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nunc tincidunt malesuada auctor. Sed vel venenatis metus. Nulla imperdiet, elit in finibus porttitor, ipsum nisl fermentum nisi, vitae dignissim nisi erat ut risus. Duis euismod lobortis lectus at dapibus. Nunc ex leo, cursus non neque in, egestas placerat libero. In massa arcu, suscipit ac placerat non, molestie ut diam.";


            return p;
        }

    }
}