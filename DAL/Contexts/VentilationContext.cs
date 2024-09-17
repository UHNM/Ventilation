using Domain.Entities.Equipment;
using System.Data.Entity;

namespace DAL.Contexts
{
    public class VentilationContext : DbContext, IVentilationContext
    {
        public VentilationContext()
     : base("Ventilation")
        {
            //todo: http://stackoverflow.com/questions/15504465/entityframework-code-first-custom-connection-string-and-migrations
            // http://stackoverflow.com/questions/21165364/ef6-dbcontext-dynamic-connection-string
            // http://stackoverflow.com/questions/21307461/set-ef-6-connection-string-dynamically
            // Figure out how to get current identity.
            // If they're an AD user connect using impersonate ?
            // If they're not, get sql username/pwd for them & connect using that
            // This is to enable us to use suser_sname() etc within audit triggers to idenity who made the change.

            System.Data.Entity.Database.SetInitializer<VentilationContext>(null); // Prevent EF checking db structure every time it initialises.
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }


        public IDbSet<Equipment> Equipments { get; set; }
    }
}
