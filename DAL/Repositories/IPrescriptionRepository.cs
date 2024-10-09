
using Domain.Entities.Complex;

namespace DAL.Repositories
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<PrescriptionPropertyCx>> GetPrescriptionResponses(int? prescriptionId);

        Task<IEnumerable<EquipmentPropertyCx>> GetPrescriptionEquipmentProperties(int? equipmentId);
    }
}
