
using DAL.Repositories;
using Domain.Entities.Complex;
using Domain.Models;

namespace BAL.Managers.DefaultImplementations
{
    public class StockManager : IStockManager
    {
        private readonly IStockRepository _dynamicResponseRepository;


        public StockManager(IStockRepository dynamicResponseRepository)
        {
            _dynamicResponseRepository = dynamicResponseRepository;
        }

        public async Task<List<StockItem>> FindStock(string clinicalTechRef)
        {
            var dto = await _dynamicResponseRepository.FindStock(clinicalTechRef);
            return await Task.FromResult(GetStockFromDto(dto));
        }

        public async Task<IEnumerable<StockItem>> GetStockList()
        {
            var dto = await _dynamicResponseRepository.GetStockList();
            return await Task.FromResult(GetStockFromDto(dto));
        }

        private static List<StockItem> GetStockFromDto(IEnumerable<StockItemCx> Dto)
        {
            if (Dto != null)
            {
                List<StockItem> stockItems = new List<StockItem>();

                foreach (StockItemCx stock in Dto)
                {
                    StockItem s = new StockItem();
                    s.StockId = stock.StockId;
                    s.ClinicalReference = stock.ClinicalReference;
                    s.EquipmentId = stock.EquipmentId;
                    s.EquipmentType = stock.EquipmentType;
                    s.EquipmentTypeId = stock.EquipmentTypeId;
                    s.EquipmentName = stock.EquipmentName;
                    s.SupplierName = stock.SupplierName;
                    s.SerialNumber = stock.SerialNumber;
                    s.ServiceDate = stock.ServiceDate;
                    stockItems.Add(s);
                }

                return stockItems;
            }
            return null;
        }


        private static StockItem GetStockItemFromDto(StockItemCx Dto)
        {
            if (Dto != null)
            {
                StockItem s = new StockItem();
                s.StockId = Dto.StockId;
                s.ClinicalReference = Dto.ClinicalReference;
                s.EquipmentId = Dto.EquipmentId;
                s.EquipmentType = Dto.EquipmentType;
                s.EquipmentTypeId = Dto.EquipmentTypeId;
                s.EquipmentName = Dto.EquipmentName;
                s.SupplierName = Dto.SupplierName;
                s.SerialNumber = Dto.SerialNumber;
                s.ServiceDate = Dto.ServiceDate;
                return s;
            }
            return null;
        }

        public async Task<int> SaveStockItem(StockItem item)
        {
            var dto = await _dynamicResponseRepository.SaveStockItem(item);
            return await Task.FromResult(dto);
        }

        public async Task<StockItem> GetStockItem(int stockId)
        {
            var dto = await _dynamicResponseRepository.GetStockItem(stockId);
            return await Task.FromResult(GetStockItemFromDto(dto));
        }

    }
}
