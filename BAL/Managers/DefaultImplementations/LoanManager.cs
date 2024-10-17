
using DAL.Repositories;
using Domain.Entities.Complex;
using Domain.Models;


namespace BAL.Managers.DefaultImplementations
{
    public class LoanManager : ILoanManager
    {
        private readonly ILoanRepository _dynamicResponseRepository;


        public LoanManager(ILoanRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }

        public async Task<List<Prescription>> GetPrescriptionsForALoan(int? loanId)
        {
            var dto = await _dynamicResponseRepository.GetPrescriptionsForALoan(loanId);
            return await Task.FromResult(GetPrescriptionFromDto(dto));
        }

        public async Task<List<Consumable>> GetConsumablesForALoan(int? loanId)
        {
            var dto = await _dynamicResponseRepository.GetConsumablesForALoan(loanId);
            return await Task.FromResult(GetConsumableFromDto(dto));
        }

        private static List<Prescription> GetPrescriptionFromDto(IEnumerable<PrescriptionCx> Dto)
        {
            if (Dto != null)
            {
                List<Prescription> prescriptions = new List<Prescription>();

                foreach (PrescriptionCx prescription in Dto)
                {
                    Prescription p  = new Prescription();
                    p.Id = prescription.Id;
                    p.EquipmentId = prescription.EquipmentId;
                    p.LoanId    = prescription.LoanId;
                    p.PrescriptionDate = prescription.PrescriptionDate;
                    prescriptions.Add(p);
                }

                return prescriptions;
            }
            return null;
        }

        private static List<Consumable> GetConsumableFromDto(IEnumerable<ConsumableCx> Dto)
        {
            if (Dto != null)
            {
                List<Consumable> consumables = new List<Consumable>();

                foreach (ConsumableCx consumable in Dto)
                {
                    Consumable c = new Consumable();
                    c.Id = consumable.Id;
                    c.EquipmentId = consumable.EquipmentId;
                    c.EquipmentName = consumable.EquipmentName;
                    c.EquipmentType = consumable.EquipmentType;
                    c.EquipmentTypeId = consumable.EquipmentTypeId;
                    c.LoanId = consumable.LoanId;
                    c.ConsumableDate = consumable.ConsumableDate;
                    c.SupplierName = consumable.SupplierName;
                    c.SerialNumber = consumable.SerialNumber;
                    c.DeliveryMethod = consumable.DeliveryMethod;
                    c.DeliveryMethodName = consumable.DeliveryMethodName;
                    c.Comments = consumable.Comments;
                    consumables.Add(c);
                }

                return consumables;
            }
            return null;
        }
    }
}
