
using DAL.Contexts;
using Domain.Entities.Complex;
using Domain.Models;
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

        public async Task<IEnumerable<StockItemCx>> GetStockList()
        {
            IEnumerable<StockItemCx> stockItems = new List<StockItemCx>();

            StockItemCx s = new StockItemCx();
            s.StockId = 1;
            s.ClinicalReference = "XYZ 123";
            s.EquipmentId = 2;
            s.EquipmentType = "Ventilator";
            s.EquipmentTypeId = 80;
            s.EquipmentName = "Stellar 150";
            s.SupplierName = "Phillips";
            s.SerialNumber = "999";
            s.ServiceDate = new DateTime(2025, 9, 23);

            StockItemCx s1 = new StockItemCx();
            s1.StockId = 2;
            s1.ClinicalReference = "XYZ 456";
            s1.EquipmentId = 3;
            s1.EquipmentType = "Ventilator";
            s1.EquipmentTypeId = 80;
            s1.EquipmentName = "Nippy 1000";
            s1.SupplierName = "Siemens";
            s1.SerialNumber = "888";
            s1.ServiceDate = new DateTime(2025, 7, 31);

            StockItemCx s2 = new StockItemCx();
            s2.StockId = 3;
            s2.ClinicalReference = "86896986";
            s2.EquipmentId = 3;
            s2.EquipmentType = "Ventilator";
            s2.EquipmentTypeId = 80;
            s2.EquipmentName = "Nippy 1000";
            s2.SupplierName = "Siemens";
            s2.SerialNumber = "9999777";
            s2.ServiceDate = new DateTime(2026, 7, 18);

            StockItemCx s3 = new StockItemCx();
            s3.StockId = 4;
            s3.ClinicalReference = "56565";
            s3.EquipmentId = 678678;
            s3.EquipmentType = "Nebuliser";
            s3.EquipmentTypeId = 81;
            s3.EquipmentName = "Some Nebuliser";
            s3.SupplierName = "random";
            s3.SerialNumber = "432846326";
            s3.ServiceDate = new DateTime(2026, 4, 21);

            stockItems = stockItems.Append(s);
            stockItems = stockItems.Append(s1);
            stockItems = stockItems.Append(s2);
            stockItems = stockItems.Append(s3);

            await Task.Delay(100);
            return stockItems;
        }

        public async Task<int> SaveStockItem(StockItem item)
        {
            //if tyhe loan Id is null do an insert, if not do an update. return the Loan Id

            int Id = 123456;

            await Task.Delay(200);
            return Id;

        }
    }
}
