
using DAL.Contexts;
using Domain.Entities.Complex;
using Domain.Models;

namespace DAL.Repositories.DefaultImplementations
{
    public class ConsumableRepository : Repository, IConsumableRepository
    {
        public ConsumableRepository(IVentilationContext context)
          : base(context)
        {
        }

        public async Task<ConsumableCx> GetConsumable(int consumableId)
        {

            ConsumableCx c = new ConsumableCx();

            //we need drop downs for equipment and delivery method
            c.Id = consumableId;
            c.EquipmentName = "Facemask - Medium Phillips";
            c.EquipmentId = 456789;
            c.EquipmentType = "Mask";
            c.SerialNumber = null;
            c.SupplierName = "Phillips";
            c.ConsumableDate = new DateTime(2024, 10, 15);
            c.LoanId = 1111; //will already have the saved loan Id?
            c.DeliveryMethod = "Post";
            c.Comments = "Some comments about sending the consumable out in the post";


            await Task.Delay(100);
            return c;




        }

        public async Task<int> SaveConsumable(Consumable consumable)
        {
            //if the consumable already has an Id , then update, otherwise insert
            //return the new Id to the front end

            int Id = 1000;

            await Task.Delay(200);
            return Id;




        }
    }
}
