﻿
using Domain.Entities.Complex;
using Domain.Models;

namespace BAL.Managers
{
    public interface IStockManager
    {
        Task<List<StockItem>> FindStock(string clinicalTechRef);


    }
}