
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

        public async Task<ConsumableDetailCx> GetConsumable(int? consumableId, int? loanId)
        {
            //covers a get for both new and edit, if a new, we won't have a consumable Id
            //TODO: we could spilt the equipment list out into a separate method and do a Task.WhenAll in the manager??

            ConsumableDetailCx detail = new ConsumableDetailCx();
            ConsumableCx c = new ConsumableCx();

            //we need drop downs for equipment and delivery method
            //Put a bool in the equipment Table to say if the equipment is a consumable or not
            c.Id = consumableId;
           
            c.EquipmentId = 11;
            c.EquipmentTypeId = 80;
            c.SerialNumber = null;
            c.SupplierName = null;
            c.ConsumableDate = new DateTime(2024, 10, 15);
            c.LoanId = 1111; //will already have the saved loan Id?
            c.DeliveryMethod = 1;
            c.DeliveryMethodName = "Posted";
            c.Comments = "Some comments about sending the consumable out in the post";

            detail.Consumable = c;

            List<LookupCx> DeliveryMethods = new List<LookupCx>();

            LookupCx l = new LookupCx();
            l.Key = 1;
            l.Value = "Posted";

            LookupCx l1 = new LookupCx();
            l1.Key = 2;
            l1.Value = "Collected";

            LookupCx l2 = new LookupCx();
            l2.Key = 1;
            l2.Value = "Courier";


            DeliveryMethods.Add(l);
            DeliveryMethods.Add(l1);
            DeliveryMethods.Add(l2);

            detail.DeliveryMethods = DeliveryMethods;

            List<EquipmentTypeCx> EquipmentTypes  = new List<EquipmentTypeCx>();

            EquipmentTypeCx t = new EquipmentTypeCx();
            t.Id = 80;
            t.EquipmentTypeName = "Mask";

            EquipmentTypeCx t1 = new EquipmentTypeCx();
            t1.Id = 81;
            t1.EquipmentTypeName = "Filter";

            EquipmentTypeCx t2 = new EquipmentTypeCx();
            t2.Id = 82;
            t2.EquipmentTypeName = "Tubing";

            EquipmentTypes.Add(t);
            EquipmentTypes.Add(t1);
            EquipmentTypes.Add(t2);

            detail.EquipmentTypes = EquipmentTypes;

            List<EquipmentBaseCx> EquipmentList = new List<EquipmentBaseCx>();

            EquipmentBaseCx e = new EquipmentBaseCx();
            e.EquipmentTypeId = 80;
            e.EquipmentId = 10;
            e.EquipmentName = "Face mask 1";

            EquipmentBaseCx e1 = new EquipmentBaseCx();
            e1.EquipmentTypeId = 80;
            e1.EquipmentId = 11;
            e1.EquipmentName = "Face mask 2";

            EquipmentBaseCx e2 = new EquipmentBaseCx();
            e2.EquipmentTypeId = 80;
            e2.EquipmentId = 11;
            e2.EquipmentName = "Face mask 3";

            EquipmentList.Add(e);
            EquipmentList.Add(e1);
            EquipmentList.Add(e2);

            EquipmentBaseCx e3 = new EquipmentBaseCx();
            e3.EquipmentTypeId = 81;
            e3.EquipmentId = 20;
            e3.EquipmentName = "Filter 1";

            EquipmentBaseCx e4 = new EquipmentBaseCx();
            e4.EquipmentTypeId = 81;
            e4.EquipmentId = 20;
            e4.EquipmentName = "Filter 2";

            EquipmentBaseCx e5 = new EquipmentBaseCx();
            e5.EquipmentTypeId = 81;
            e5.EquipmentId = 20;
            e5.EquipmentName = "Filter 3";

            EquipmentList.Add(e3);
            EquipmentList.Add(e4);
            EquipmentList.Add(e5);

            EquipmentBaseCx e6 = new EquipmentBaseCx();
            e6.EquipmentTypeId = 82;
            e6.EquipmentId = 30;
            e6.EquipmentName = "One Type of Tubing";

            EquipmentList.Add(e6);



            detail.EquipmentList = EquipmentList;   





            await Task.Delay(100);
            return detail;




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
