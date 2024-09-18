using DAL.Contexts;
using Domain.Entities.Complex;
using System.Linq;

namespace DAL.Repositories.DefaultImplementations
{
    public class EquipmentTypeRepository : Repository, IEquipmentTypeRepository
    {
        public EquipmentTypeRepository(IVentilationContext context)
    : base(context)
        {
        }

        public IEnumerable<EquipmentTypeCx> GetEquipmentTypes()
        {
            IEnumerable<EquipmentTypeCx> types = new List<EquipmentTypeCx>();

            EquipmentTypeCx e1 = new EquipmentTypeCx();
            e1.Id = 1;
            e1.EquipmentTypeName = "Ventilator";
            e1.Available = true;
            e1.CreatedDate = new DateTime(2022, 10, 12);
            e1.CreatedBy = "Dr Thomas";
            e1.DeletedBy = null;
            e1.DeletedDate = DateTime.MinValue;
            types = types.Append(e1);

            EquipmentTypeCx e2 = new EquipmentTypeCx();
            e2.Id = 1;
            e2.EquipmentTypeName = "Face Mask";
            e2.Available = true;
            e2.CreatedDate = new DateTime(2024, 1, 8);
            e2.CreatedBy = "Sue Whitfield";
            e2.DeletedBy = null;
            e2.DeletedDate = DateTime.MinValue;
            types = types.Append(e2);

          

            //equip = equip.Concat(new EquipmentCx[] { e1 });


            //_context.Database.Connection.Open();
            //try
            //{
            //    var spArgs = BuildProcCommand("USP_APP_CONSULTANT_LIST_BY_SPECIALTY",

            //           new List<object>
            //    {
            //     new SqlParameter("@SPECT_REFNO",id)
            //    });

            //    e = _context.Database.SqlQuery<EquipmentCx>(spArgs.Item1, spArgs.Item2).ToList();

            //}
            //finally
            //{
            //    _context.Database.Connection.Close();
            //}

            return types;
        }

    }
}
