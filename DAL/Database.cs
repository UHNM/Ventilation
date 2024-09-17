using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
//using log4net;
//using UHNS.IPortal.Shared.Performance;
//using UHNS.IPortal.Configuration;


namespace DAL
{
    /// <summary>
    /// 
    /// </summary>
    public static class Database
    {
      //  private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static string logBoilerPlate = "SQL PERFORMANCE(DbCommand) ExecuteDbReader.CommandText: {0}, Duration: {1}, Config.PerformanceMonitoringDefaultTime: {2}";
        #region Db

        public static DbDataReader ExecuteReader(DbCommand com)
        {
            var res = ExecuteDbReader(com);
            return res;
        }

        public static DbDataReader ExecuteDbReader(DbCommand com)
        {
         //   PerformanceTimer time = new PerformanceTimer();
          //  time.Start();
            DbDataReader rdr = com.ExecuteReader();
           // time.Stop();
            //if (Config.EnablePerformanceMonitoring)
            //    try
            //    {
            //        if (time.SecondsElapsed >= Config.PerformanceMonitoringDefaultTime)
            //        {
            //            log.Warn(string.Format(logBoilerPlate, com.CommandText, time.Duration, Config.PerformanceMonitoringDefaultTime.ToString()));
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error(MethodBase.GetCurrentMethod().Name + ex.Message + " " + time.Duration + " " + com.CommandText);
            //    }

            return rdr;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(DbCommand com)
        {
          //  PerformanceTimer time = new PerformanceTimer();
          //  time.Start();
            int i = com.ExecuteNonQuery();
          //  time.Stop();
            //if (Config.EnablePerformanceMonitoring)
            //    try
            //    {

            //        if (time.SecondsElapsed >= Config.PerformanceMonitoringDefaultTime)
            //        {
            //            log.Warn(string.Format(logBoilerPlate, com.CommandText, time.Duration, Config.PerformanceMonitoringDefaultTime.ToString()));
            //        }

            //        return i;
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error(MethodBase.GetCurrentMethod().Name + ex.Message + " " + time.Duration + " " + com.CommandText);
            //    }

            return i;
        }



        #endregion

        #region Sql


        /// <summary>
        /// 
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(SqlCommand com)
        {
            var res = ExecuteReader(com, CommandBehavior.Default);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="com"></param>
        /// <param name="behaviour"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(SqlCommand com, CommandBehavior behaviour)
        {
           // PerformanceTimer time = new PerformanceTimer();
           // time.Start();
            SqlDataReader rdr = com.ExecuteReader(behaviour);
          //  time.Stop();
            //if (Config.EnablePerformanceMonitoring)
            //    try
            //    {
            //        if (time.SecondsElapsed >= Config.PerformanceMonitoringDefaultTime)
            //        {
            //            log.Warn(string.Format(logBoilerPlate, com.CommandText, time.Duration, Config.PerformanceMonitoringDefaultTime.ToString()));
            //        }

            //        return rdr;
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error(MethodBase.GetCurrentMethod().Name + ex.Message + " " + time.Duration + " " + com.CommandText);
            //    }
            return rdr;
        }

        /// <summary>
        /// Returns the first Row in the first column
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public static object ExecuteScalar(DbCommand com)
        {
           // PerformanceTimer time = new PerformanceTimer();
            //time.Start();
            object ob = com.ExecuteScalar();
           // time.Stop();
            //if (Config.EnablePerformanceMonitoring)
            //    try
            //    {

            //        if (time.SecondsElapsed >= Config.PerformanceMonitoringDefaultTime)
            //        {
            //            log.Warn(string.Format(logBoilerPlate, com.CommandText, time.Duration, Config.PerformanceMonitoringDefaultTime.ToString()));
            //        }

            //        return ob;
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error(MethodBase.GetCurrentMethod().Name + ex.Message + " " + time.Duration + " " + com.CommandText);
            //    }


            return ob;
        }




        /// <summary>
        /// Returns the number of rows affected
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(SqlCommand com)
        {
           // PerformanceTimer time = new PerformanceTimer();
           // time.Start();
            int i = com.ExecuteNonQuery();
           // time.Stop();
            //if (Config.EnablePerformanceMonitoring)
            //    try
            //    {

            //        if (time.SecondsElapsed >= Config.PerformanceMonitoringDefaultTime)
            //        {
            //            log.Warn(string.Format(logBoilerPlate, com.CommandText, time.Duration, Config.PerformanceMonitoringDefaultTime.ToString()));
            //        }

            //        return i;
            //    }
            //    catch (Exception ex)
            //    {
            //        log.Error(MethodBase.GetCurrentMethod().Name + ex.Message + " " + time.Duration + " " + com.CommandText);
            //    }

            return i;
        }
        #endregion
    }
}
