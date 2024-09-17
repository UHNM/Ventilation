using Domain.Entities.Equipment;
using System.Data;
using System.Data.Entity;

namespace DAL.Contexts
{
    public interface IVentilationContext : IDbContext
    {
      
        #region Equipment
        IDbSet<Equipment> Equipments { get; set; }

        #endregion

    }
}
