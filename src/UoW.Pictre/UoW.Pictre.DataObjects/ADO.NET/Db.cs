using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.Pictre.DataObjects.ADO.NET
{
    public static class Db
    {
        //TODO : Temp

        /// <summary>
        /// Inserts an item into the database
        /// </summary>
        /// <param name="sql">Inline query or Stored Procedure name</param>
        /// <param name="connectionStringName">AppSettings Connection Name</param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int Insert(string sql, string connectionString = null, object[] parms = null)
        {
            return 0;
        }
    }
}
