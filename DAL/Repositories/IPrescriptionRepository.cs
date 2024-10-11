
using Domain.Entities.Complex;
using Domain.Models;

namespace DAL.Repositories
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<PrescriptionPropertyCx>> GetPrescriptionResponses(int? prescriptionId);

        Task<IEnumerable<EquipmentPropertyCx>> GetPrescriptionEquipmentProperties(int? equipmentId);

        Task<int> SavePrescription(PrescriptionDetail prescription);
    }

}
