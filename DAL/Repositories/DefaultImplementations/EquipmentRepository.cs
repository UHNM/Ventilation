using DAL.Contexts;
using Domain.Entities.Complex;

namespace DAL.Repositories.DefaultImplementations
{
    public class EquipmentRepository : Repository, IEquipmentRepository
    {
        public EquipmentRepository(IVentilationContext context)
            : base(context)
        {
        }

        //public IEnumerable<EquipmentCx> GetEquipmentList()
        //{
        //    IEnumerable<EquipmentCx> equip = new List<EquipmentCx>();

        //    EquipmentCx e1 = new EquipmentCx();
        //    e1.Id = 1;
        //    e1.EquipmentName = "Nippy 1000";
        //    e1.SupplierId = 10;
        //    e1.EquipmentTypeId = 20;
        //    e1.Available = true;
        //    e1.CreatedDate = new DateTime(2024, 3, 16);
        //    e1.CreatedBy = "Dr Thomas";
        //    e1.DeletedBy = null;
        //    e1.DeletedDate = DateTime.MinValue;
        //    equip = equip.Append(e1);

        //    EquipmentCx e2 = new EquipmentCx();
        //    e2.Id = 1;
        //    e2.EquipmentName = "Stellar 150";
        //    e2.SupplierId = 11;
        //    e2.EquipmentTypeId = 20;
        //    e2.Available = true;
        //    e2.CreatedDate = new DateTime(2024, 7, 21);
        //    e2.CreatedBy = "Sue Whitfield";
        //    e2.DeletedBy = null;
        //    e2.DeletedDate = DateTime.MinValue;
        //    equip = equip.Append(e2);

        //    EquipmentCx e3 = new EquipmentCx();
        //    e3.Id = 1;
        //    e3.EquipmentName = "Some Mask";
        //    e3.SupplierId = 12;
        //    e3.EquipmentTypeId = 30;
        //    e3.Available = true;
        //    e3.CreatedDate = new DateTime(2024, 7, 21);
        //    e3.CreatedBy = "Sue Whitfield";
        //    e3.DeletedBy = null;
        //    e3.DeletedDate = DateTime.MinValue;
        //    equip = equip.Append(e3);



        //    //equip = equip.Concat(new EquipmentCx[] { e1 });


        //    //_context.Database.Connection.Open();
        //    //try
        //    //{
        //    //    var spArgs = BuildProcCommand("USP_APP_CONSULTANT_LIST_BY_SPECIALTY",

        //    //           new List<object>
        //    //    {
        //    //     new SqlParameter("@SPECT_REFNO",id)
        //    //    });

        //    //    e = _context.Database.SqlQuery<EquipmentCx>(spArgs.Item1, spArgs.Item2).ToList();

        //    //}
        //    //finally
        //    //{
        //    //    _context.Database.Connection.Close();
        //    //}

        //    return equip;
        //}
    }
}
