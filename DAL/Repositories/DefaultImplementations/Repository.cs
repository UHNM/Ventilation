using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace DAL.Repositories.DefaultImplementations
{
    public class Repository : IRepository
    {
        private readonly IDbContext _context;
        private bool _disposed;

        public Repository(IDbContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Create argument & object array for passing to ExecuteSqlCommand.
        /// i.e. "exec procname @arg1=@arg1, @arg2=@arg2 OUTPUT", [param,param]
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="paramsList"></param>
        /// <returns></returns>
        internal static Tuple<string, object[]> BuildProcCommand(string procName, List<object> paramsList)
        {
            var arguments = (from SqlParameter p in paramsList select string.Format("{0}={1}{2}", p.ParameterName, p.ParameterName, (p.Direction == ParameterDirection.Output || p.Direction == ParameterDirection.InputOutput) ? " OUTPUT" : "")).ToList();

            var cmd = new StringBuilder("EXEC ");
            cmd.Append(procName);
            cmd.Append(" ");
            cmd.Append(string.Join(", ", arguments));

            return new Tuple<string, object[]>(cmd.ToString(), paramsList.ToArray());
        }

        /// <summary>
        /// Create sql parameters for object.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        internal static List<object> BuildParameters(object parameters)
        {
            return parameters.GetType().GetProperties().Select(propInfo => new SqlParameter("@" + propInfo.Name, propInfo.GetValue(parameters, null) ?? DBNull.Value)).Cast<object>().ToList();
        }

        /// <summary>
        /// Create exec proc command string.
        /// </summary>
        /// <param name="procName"></param>
        /// <returns></returns>
        internal static string BuildProcCommand(string procName)
        {
            var cmd = new StringBuilder("EXEC ");
            cmd.Append(procName);
            return cmd.ToString();
        }
    }
}

