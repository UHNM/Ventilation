
using DAL.Contexts;
using Domain.Entities.Complex;
using System.Net.Http.Headers;

namespace DAL.Repositories.DefaultImplementations
{
    public class StockRepository : Repository, IStockRepository
    {

        public StockRepository(IVentilationContext context)
           : base(context)
        {
        }

        public async Task<IEnumerable<StockItemCx>> FindStock(string clinicalTechRef)
        {
            IEnumerable<StockItemCx> stockItems = new List<StockItemCx>();

            StockItemCx s = new StockItemCx();
            s.StockId = 1;
            s.ClinicalReference = "XYZ 123";
            s.EquipmentId = 2;
            s.EquipmentType = "Ventilator";
            s.EquipmentTypeId = 50;
            s.EquipmentName = "Stellar";
            s.SupplierName = "Phillips";
            s.SerialNumber = "999";
            s.ServiceDate = new DateTime(2025, 9, 23);

            StockItemCx s1 = new StockItemCx();
            s1.StockId = 2;
            s1.ClinicalReference = "XYZ 456";
            s1.EquipmentId = 3;
            s1.EquipmentType = "Ventilator";
            s.EquipmentTypeId = 50;
            s1.EquipmentName = "Nippy 1000";
            s1.SupplierName = "Siemens";
            s1.SerialNumber = "888";
            s1.ServiceDate = new DateTime(2025, 7, 31);

            stockItems = stockItems.Append(s);
            stockItems = stockItems.Append(s1);
            await Task.Delay(100);
            return stockItems;
        }
    }
}
