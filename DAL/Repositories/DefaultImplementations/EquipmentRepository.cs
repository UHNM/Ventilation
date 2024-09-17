using DAL.Contexts;
using Domain.Entities.Complex;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace DAL.Repositories.DefaultImplementations
{
    public class EquipmentRepository : Repository, IEquipmentRepository
    {

        //private readonly IVentilationContext _context;

        public EquipmentRepository(IVentilationContext context)
            : base(context)
        {
            //_context = context;
        }

        public IEnumerable<EquipmentCx> GetEquipmentList()
        {
            IEnumerable<EquipmentCx> equip = new List<EquipmentCx>();

            EquipmentCx e1 = new EquipmentCx();
            e1.Id = 1;
            e1.EquipmentName = "Nippy 1000";
            equip = equip.Append(e1);



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

            return equip;
        }
    }
}
