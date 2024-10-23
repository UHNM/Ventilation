
using DAL.Repositories;
using Domain.Entities.Complex;
using Domain.Models;
using Domain.Models.EquipmentDetails;

namespace BAL.Managers.DefaultImplementations
{
    public class PatientListManager : IPatientListManager
    {

        private readonly IPatientListRepository _dynamicResponseRepository;


        public PatientListManager(IPatientListRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }

        //public async Task<List<PatientListItem>> GetPatientList()
        //{
        //    var dto = await _dynamicResponseRepository.GetPatientList();
        //    return await Task.FromResult(GetPatientListItemsFromDto(dto));
        //}


        public async Task<PatientListLoan> GetPatientList()
        {
            var p = _dynamicResponseRepository.GetPatientListPatients();
            var l = _dynamicResponseRepository.GetPatientListLoans();

            var t = Task.WhenAll(
                p,
                l);
            await t;

            List<PatientBase> patients = new List<PatientBase>();
            List<Loan> loans = new List<Loan>();

            patients = GetPatientsFromDto(await p);
            loans = GetLoansFromDto(await l);

            PatientListLoan patientsandLoans = new PatientListLoan();
            patientsandLoans.Patients = patients;
            patientsandLoans.PatientLoans = loans;

            return await Task.FromResult(patientsandLoans);
        }



        private static List<PatientBase> GetPatientsFromDto(IEnumerable<PatientBaseCx> Dto)
        {
            if (Dto != null)
            {
                List<PatientBase> patients = new List<PatientBase>();

                foreach (PatientBaseCx pat in Dto)
                {
                    PatientBase p = new PatientBase();
                    p.Id = pat.Id;
                    p.InternalPatientId = pat.InternalPatientId;    
                    p.HospitalNumber = pat.HospitalNumber;
                    p.NHSNumber = pat.NHSNumber;
                    p.Surname = pat.Surname;
                    p.Forename = pat.Forename;
                    p.Address1  = pat.Address1;
                    p.Address2 = pat.Address2;
                    p.Address3 = pat.Address3;
                    p.Address4 = pat.Address4;
                    p.PostCode = pat.PostCode;
                    p.DateofBirth   = pat.DateofBirth;
                    p.Telephone1    = pat.Telephone1;
                    p.Telephone2 = pat.Telephone2;
                    p.CCG = pat.CCG;

                    patients.Add(p);
                }

                return patients;
            }
            return null;
        }

        private static List<Loan> GetLoansFromDto(IEnumerable<LoanCx> Dto)
        {
            if (Dto != null)
            {
                List<Loan> loans = new List<Loan>();

                foreach (LoanCx loan in Dto)
                {
                    Loan l = new Loan();
                    l.LoanId = loan.LoanId;
                    l.PatientId = loan.PatientId;
                    l.LoanDate  = loan.LoanDate;
                    l.StockId  = loan.StockId;
                    l.ClinicalReference = loan.ClinicalReference;
                    l.ServiceDate   = loan.ServiceDate;
                    l.EquipmentId = loan.EquipmentId;
                    l.EquipmentName = loan.EquipmentName;
                    l.EquipmentType = loan.EquipmentType;
                    l.EquipmentTypeId   = loan.EquipmentTypeId;
                    l.SerialNumber  = loan.SerialNumber;
                    l.SupplierName  = loan.SupplierName;


                    loans.Add(l);
                }

                return loans;
            }
            return null;
        }





        //private static List<PatientListItem> GetPatientListItemsFromDto(IEnumerable<PatientListItemCx> Dto)
        //{
        //    if (Dto != null)
        //    {
        //        List<PatientListItem> PatientItems = new List<PatientListItem>();

        //        foreach (PatientListItemCx item in Dto)
        //        {
        //            PatientListItem Loan = new PatientListItem();
        //            PatientBase Patient= new PatientBase();
        //            List<Loan> Loans = new List<Loan>();

        //            Patient.InternalPatientId = item.Patient.InternalPatientId;
        //            Patient.Id = item.Patient.Id;
        //            Patient.HospitalNumber = item.Patient.HospitalNumber;
        //            Patient.NHSNumber = item.Patient.NHSNumber;
        //            Patient.Forename =item.Patient.Forename;
        //            Patient.Surname = item.Patient.Surname;
        //            Patient.Address1 = item.Patient.Address1;
        //            Patient.Address2 = item.Patient.Address2;
        //            Patient.Address3 = item.Patient.Address3;
        //            Patient.Address4 = item.Patient.Address4;
        //            Patient.PostCode = item.Patient.PostCode;
        //            Patient.DateofBirth = item.Patient.DateofBirth;
        //            Patient.Telephone2 = item.Patient.Telephone2;
        //            Patient.Telephone1 = item.Patient.Telephone1;


        //            foreach (LoanCx stock in item.Loans)
        //            {
        //                Loan s = new Loan();
        //                s.LoanId = stock.LoanId;
        //                s.StockId = stock.StockId;
        //                s.EquipmentId = stock.EquipmentId;
        //                s.EquipmentName = stock.EquipmentName;
        //                s.SerialNumber = stock.SerialNumber;
        //                s.ClinicalReference = stock.ClinicalReference;   
        //                s.LoanDate = stock.LoanDate;
        //                Loans.Add(s);
        //            }

        //            Loan.Patient = Patient;
        //            Loan.Loans = Loans;
        //            PatientItems.Add(Loan);

        //        }

        //        return PatientItems;
        //    }
        //    return null;
        //}
    }
}
